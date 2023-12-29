using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using NierReincarnation.Core.Octo.Proto;
using NierReincarnation.Core.UnityEngine;
using NierReincarnation.Functions.Common;
using System.Net;
using System.Text;

namespace NierReincarnation.Functions;

public class AssetDbFunctions(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory) : FunctionBase
{
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient();
    private readonly ILogger _logger = loggerFactory.CreateLogger<AssetDbFunctions>();

    private static int CurrentAssetDbRevision;

    [Function(nameof(CheckOffPeak))]
    public async Task CheckOffPeak([TimerTrigger("%OffPeakCron%")] FunctionContext context)
    {
        await CheckAndNotifyRevisionChangesAsync();
        _logger.LogInformation($"{nameof(CheckOffPeak)} executed at: {DateTime.Now} with revision {CurrentAssetDbRevision}");
    }

    [Function(nameof(CheckOnPeak))]
    public async Task CheckOnPeak([TimerTrigger("%OnPeakCron%")] FunctionContext context)
    {
        await CheckAndNotifyRevisionChangesAsync();
        _logger.LogInformation($"{nameof(CheckOnPeak)} executed at: {DateTime.Now} with revision {CurrentAssetDbRevision}");
    }

    [Function(nameof(CheckNow))]
    public async Task<HttpResponseData> CheckNow([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequestData req,
        FunctionContext executionContext)
    {
        await CheckAndNotifyRevisionChangesAsync();

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        response.WriteString(CurrentAssetDbRevision.ToString());

        return response;
    }

    [Function(nameof(SendNotification))]
    public async Task<HttpResponseData> SendNotification([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequestData req,
        FunctionContext executionContext, string content)
    {
        if (!string.IsNullOrWhiteSpace(content))
        {
            await SendDiscordNotification(content);
        }

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
        response.WriteString("OK");

        return response;
    }

    private async Task CheckAndNotifyRevisionChangesAsync()
    {
        // Initialize
        Application.SystemRegion = Enum.Parse<SystemRegion>(Environment.GetEnvironmentVariable("SystemRegion")!);
        Database? db = await GetDatabaseAsync(_httpClient, _logger, CurrentAssetDbRevision);
        if (db is null) return;

        // If db revision changed, send Discord notification
        if (CurrentAssetDbRevision != 0 && CurrentAssetDbRevision < db.Revision)
        {
            await SendDiscordNotification($"<@&{Environment.GetEnvironmentVariable("DiscordPingRoleId")}> {Application.SystemRegion} asset database updated: {CurrentAssetDbRevision} -> {db.Revision}");
        }

        // Update db revision
        CurrentAssetDbRevision = db.Revision;
    }

    private async Task SendDiscordNotification(string content)
    {
        string payload = @$"
            {{
                ""username"": ""Mama"",
                ""content"": ""{content}""
            }}";
        HttpContent httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
        await _httpClient.PostAsync(Environment.GetEnvironmentVariable("DiscordWebHookUrl"), httpContent);
    }
}
