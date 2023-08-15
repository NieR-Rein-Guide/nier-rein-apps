using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using NierReincarnation.Core.Octo;
using System.Text;

namespace NierReincarnation.Functions
{
    public class AssetDbFunctions
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;

        private static int CurrentAssetDbRevision;

        private static int LatestAssetDbRevision => OctoManager.DbRevision;

        public AssetDbFunctions(IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AssetDbFunctions>();
            _httpClient = httpClientFactory.CreateClient();
        }

        [Function(nameof(CheckAssetsOffPeak))] // Every 15 minutes on the 0th second during off-peak time window
        public async Task CheckAssetsOffPeak([TimerTrigger("0 */15 * * * *", RunOnStartup = true)] FunctionContext context)
        {
            await CheckAndNotifyRevisionChangesAsync();
            _logger.LogInformation($"{nameof(CheckAssetsOffPeak)} executed at: {DateTime.Now} with revision {CurrentAssetDbRevision}");
        }

        [Function(nameof(CheckAssetsOnPeak))] // Every minute on the 30th second during on-peak time window on weekdays
        public async Task CheckAssetsOnPeak([TimerTrigger("30 * 1-2 * * 1-5")] FunctionContext context)
        {
            await CheckAndNotifyRevisionChangesAsync();
            _logger.LogInformation($"{nameof(CheckAssetsOnPeak)} executed at: {DateTime.Now} with revision {CurrentAssetDbRevision}");
        }

        private async Task CheckAndNotifyRevisionChangesAsync()
        {
            // Initialize app
            await NierReincarnationApp.InitializeApplicationAsync(new ApplicationInitArguments(false, false, true, 0));

            // If db revision changed, send Discord notification
            if (CurrentAssetDbRevision != 0 && CurrentAssetDbRevision < LatestAssetDbRevision)
            {
                await SendDiscordNotification(CurrentAssetDbRevision, LatestAssetDbRevision);
            }

            // Update db revision
            CurrentAssetDbRevision = LatestAssetDbRevision;
        }

        private async Task SendDiscordNotification(int fromRevision, int toRevision)
        {
            string payload = @$"
            {{
                ""username"": ""Mama"",
                ""content"": ""<@&{Environment.GetEnvironmentVariable("DiscordPingRoleId")}> Asset database updated: {fromRevision} -> {toRevision}""
            }}";
            HttpContent httpContent = new StringContent(payload, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(Environment.GetEnvironmentVariable("DiscordWebHookUrl"), httpContent);
        }
    }
}
