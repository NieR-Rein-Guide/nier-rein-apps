using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using NierReincarnation.Core.Octo;
using NierReincarnation.Core.UnityEngine;
using System.Text;

namespace NierReincarnation.Functions;

public class AssetDbFunctions
{
    private static readonly SemaphoreSlim _semaphore = new(1, 1);

    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    private static int CurrentGlobalAssetDbRevision;
    private static int CurrentJpAssetDbRevision;

    private static int LatestAssetDbRevision => OctoManager.DbRevision;

    public AssetDbFunctions(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<AssetDbFunctions>();
        _httpClient = httpClientFactory.CreateClient();
    }

    [Function(nameof(CheckGlobalAssetsOffPeak))] // Every 15 minutes on the 0th second during off-peak time window
    public async Task CheckGlobalAssetsOffPeak([TimerTrigger("0 */1 0-1,2-23 * * *")] FunctionContext context)
    {
        await _semaphore.WaitAsync();
        await CheckAndNotifyRevisionChangesAsync(SystemRegion.GL);
        _logger.LogInformation($"{nameof(CheckGlobalAssetsOffPeak)} executed at: {DateTime.Now} with revision {CurrentGlobalAssetDbRevision}");
        _semaphore.Release();
    }

    //[Function(nameof(CheckGlobalAssetsOnPeak))] // Every minute on the 30th second during on-peak time window on weekdays
    public async Task CheckGlobalAssetsOnPeak([TimerTrigger("0 * 1-2 * * 1-5")] FunctionContext context)
    {
        await _semaphore.WaitAsync();
        await CheckAndNotifyRevisionChangesAsync(SystemRegion.GL);
        _logger.LogInformation($"{nameof(CheckGlobalAssetsOnPeak)} executed at: {DateTime.Now} with revision {CurrentGlobalAssetDbRevision}");
        _semaphore.Release();
    }

    [Function(nameof(CheckJpAssetsOffPeak))] // Every 15 minutes on the 30th second during off-peak time window
    public async Task CheckJpAssetsOffPeak([TimerTrigger("30 */1 0-1,2-23 * * *")] FunctionContext context)
    {
        await _semaphore.WaitAsync();
        await CheckAndNotifyRevisionChangesAsync(SystemRegion.JP);
        _logger.LogInformation($"{nameof(CheckJpAssetsOffPeak)} executed at: {DateTime.Now} with revision {CurrentJpAssetDbRevision}");
        _semaphore.Release();
    }

    private async Task CheckAndNotifyRevisionChangesAsync(SystemRegion systemRegion)
    {
        // Initialize app
        Application.SystemRegion = systemRegion;
        ApplicationInitArguments args = new(false, false, true);
        NierReincarnationApp.ResetApplication();
        await NierReincarnationApp.InitializeApplicationAsync(args);

        // If db revision changed, send Discord notification
        int currentAssetDbRevision = GetCurrentAssetDbRevision(systemRegion);
        if (currentAssetDbRevision != 0 && currentAssetDbRevision < LatestAssetDbRevision)
        {
            await SendDiscordNotification(systemRegion, currentAssetDbRevision, LatestAssetDbRevision);
        }

        // Update db revision
        UpdateCurrentAssetDbRevision(systemRegion, LatestAssetDbRevision);
    }

    private static int GetCurrentAssetDbRevision(SystemRegion systemRegion) => systemRegion == SystemRegion.GL ? CurrentGlobalAssetDbRevision : CurrentJpAssetDbRevision;

    private static void UpdateCurrentAssetDbRevision(SystemRegion systemRegion, int revision)
    {
        if (systemRegion == SystemRegion.GL)
        {
            CurrentGlobalAssetDbRevision = revision;
        }
        else
        {
            CurrentJpAssetDbRevision = revision;
        }
    }

    private async Task SendDiscordNotification(SystemRegion systemRegion, int fromRevision, int toRevision)
    {
        string payload = @$"
            {{
                ""username"": ""Mama"",
                ""content"": ""<@&{Environment.GetEnvironmentVariable("DiscordPingRoleId")}> {systemRegion} asset database updated: {fromRevision} -> {toRevision}""
            }}";
        HttpContent httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
        await _httpClient.PostAsync(Environment.GetEnvironmentVariable("DiscordWebHookUrl"), httpContent);
    }
}
