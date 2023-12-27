using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using NierReincarnation.Core.Adam.Framework.Resource;
using NierReincarnation.Core.Dark.EntryPoint;
using NierReincarnation.Core.Octo;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.Octo.Proto;
using NierReincarnation.Core.UnityEngine;
using ProtoBuf;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace NierReincarnation.Functions;

public class AssetDbFunctions
{
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    private static int CurrentAssetDbRevision;

    public AssetDbFunctions(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<AssetDbFunctions>();
        _httpClient = httpClientFactory.CreateClient();
    }

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
        OctoFullSettings octoSettings = DarkOctoSetupper.CreateSetting();
        AESCrypt crypt = new(SHA256.HashData(Encoding.UTF8.GetBytes(octoSettings.A)));

        // Send request
        HttpRequestMessage req = new(HttpMethod.Get, Config.Octo.Url + $"v2/pub/a/{octoSettings.AppId}/v/{octoSettings.Version}/list/{CurrentAssetDbRevision}");
        req.Headers.Add("Accept", $"application/x-protobuf,x-octo-app/{octoSettings.AppId}");
        req.Headers.Add("X-OCTO-KEY", $"{octoSettings.ClientSecretKey}");
        HttpResponseMessage res = await _httpClient.SendAsync(req);

        // Handle response
        if (!res.IsSuccessStatusCode)
        {
            _logger.LogError($"Error while fetching {Application.SystemRegion} asset list: {res.ReasonPhrase} - {res.StatusCode}");
            return;
        }

        byte[] bytes = await res.Content.ReadAsByteArrayAsync();
        bytes = DecryptAes(crypt, bytes);

        using MemoryStream memoryStream = new(bytes);
        Database db = Serializer.Deserialize<Database>(memoryStream);

        // If db revision changed, send Discord notification
        if (CurrentAssetDbRevision != 0 && CurrentAssetDbRevision < db.Revision)
        {
            await SendDiscordNotification($"<@&{Environment.GetEnvironmentVariable("DiscordPingRoleId")}> {Application.SystemRegion} asset database updated: {CurrentAssetDbRevision} -> {db.Revision}");
        }

        // Update db revision
        CurrentAssetDbRevision = db.Revision;
    }

    private static byte[] DecryptAes(AESCrypt crypt, byte[] bytes)
    {
        byte[] iv = new byte[0x10];
        Array.Copy(bytes, iv, iv.Length);
        crypt.UpdateIV(iv);

        using MemoryStream ms = new(bytes, 0x10, bytes.Length - 0x10);
        return crypt.Decrypt(ms);
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
