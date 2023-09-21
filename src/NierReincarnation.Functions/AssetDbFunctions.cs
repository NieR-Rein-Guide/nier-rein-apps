using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using NierReincarnation.Core.Adam.Framework.Resource;
using NierReincarnation.Core.Dark.EntryPoint;
using NierReincarnation.Core.Octo;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.Octo.Proto;
using NierReincarnation.Core.UnityEngine;
using ProtoBuf;
using System.Security.Cryptography;
using System.Text;

namespace NierReincarnation.Functions;

public class AssetDbFunctions
{
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    private static int CurrentGlobalAssetDbRevision;
    private static int CurrentJpAssetDbRevision;

    public AssetDbFunctions(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<AssetDbFunctions>();
        _httpClient = httpClientFactory.CreateClient();
    }

    [Function(nameof(CheckGlobalAssetsOffPeak))] // Every 15 minutes on the 0th second during off-peak time window
    public async Task CheckGlobalAssetsOffPeak([TimerTrigger("0 */15 * * * *")] FunctionContext context)
    {
        await CheckAndNotifyRevisionChangesAsync(SystemRegion.GL);
        _logger.LogInformation($"{nameof(CheckGlobalAssetsOffPeak)} executed at: {DateTime.Now} with revision {CurrentGlobalAssetDbRevision}");
    }

    [Function(nameof(CheckGlobalAssetsOnPeak))] // Every minute on the 30th second during on-peak time window on weekdays
    public async Task CheckGlobalAssetsOnPeak([TimerTrigger("30 * 1-2 * * 1-5")] FunctionContext context)
    {
        await CheckAndNotifyRevisionChangesAsync(SystemRegion.GL);
        _logger.LogInformation($"{nameof(CheckGlobalAssetsOnPeak)} executed at: {DateTime.Now} with revision {CurrentGlobalAssetDbRevision}");
    }

    [Function(nameof(CheckJpAssetsOffPeak))] // Every 15 minutes on the 15th second during off-peak time window
    public async Task CheckJpAssetsOffPeak([TimerTrigger("15 */15 * * * *")] FunctionContext context)
    {
        await CheckAndNotifyRevisionChangesAsync(SystemRegion.JP);
        _logger.LogInformation($"{nameof(CheckJpAssetsOffPeak)} executed at: {DateTime.Now} with revision {CurrentJpAssetDbRevision}");
    }

    private async Task CheckAndNotifyRevisionChangesAsync(SystemRegion systemRegion)
    {
        // Initialize
        Application.SystemRegion = systemRegion;
        OctoFullSettings octoSettings = DarkOctoSetupper.CreateSetting();
        AESCrypt crypt = new(SHA256.HashData(Encoding.UTF8.GetBytes(octoSettings.A)));
        int currentAssetDbRevision = GetCurrentAssetDbRevision(systemRegion);

        // Send request
        HttpRequestMessage req = new(HttpMethod.Get, Config.Octo.Url + $"v2/pub/a/{octoSettings.AppId}/v/{octoSettings.Version}/list/{currentAssetDbRevision}");
        req.Headers.Add("Accept", $"application/x-protobuf,x-octo-app/{octoSettings.AppId}");
        req.Headers.Add("X-OCTO-KEY", $"{octoSettings.ClientSecretKey}");
        HttpResponseMessage res = await _httpClient.SendAsync(req);

        // Handle response
        if (!res.IsSuccessStatusCode)
        {
            _logger.LogError($"Error while fetching {systemRegion} asset list: {res.ReasonPhrase} - {res.StatusCode}");
            return;
        }

        byte[] bytes = await res.Content.ReadAsByteArrayAsync();
        bytes = DecryptAes(crypt, bytes);

        using MemoryStream memoryStream = new(bytes);
        Database db = Serializer.Deserialize<Database>(memoryStream);

        // If db revision changed, send Discord notification
        if (currentAssetDbRevision != 0 && currentAssetDbRevision < db.Revision)
        {
            await SendDiscordNotification(systemRegion, currentAssetDbRevision, db.Revision);
        }

        // Update db revision
        UpdateCurrentAssetDbRevision(systemRegion, db.Revision);
    }

    private static byte[] DecryptAes(AESCrypt crypt, byte[] bytes)
    {
        byte[] iv = new byte[0x10];
        Array.Copy(bytes, iv, iv.Length);
        crypt.UpdateIV(iv);

        using MemoryStream ms = new(bytes, 0x10, bytes.Length - 0x10);
        return crypt.Decrypt(ms);
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
