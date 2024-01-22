using DustInTheWind.ConsoleTools.Controls.InputControls;
using DustInTheWind.ConsoleTools.Controls.Spinners;
using NierReincarnation.Core.Dark.EntryPoint;

namespace NierReincarnation.Datamine.Command;

public class MasterDatabaseWatcherMenuCommand(MasterDatabaseWatcherMenuCommandArg arg) : AbstractWatcherMenuCommand<MasterDatabaseWatcherMenuCommandArg, WatcherResult>(arg)
{
    private static readonly object _lockObj = new();

    private const int _batchSize = 10000;

    public override bool IsActive => Program.AppSettings.IsSetup && Program.AppSettings.IsOfflineMode;

    public override bool Reset => false;

    public override bool Login => false;

    public override bool UseLocalizations => false;

    public override int Revision => Program.AppSettings.DbRevision;

    public override TimeSpan Interval => TimeSpan.FromMinutes(10);

    public override async Task<WatcherResult> ExecuteAsync(MasterDatabaseWatcherMenuCommandArg arg)
    {
        string okText = StringValue.QuickRead("WARNING!!! Do NOT use this without an active VPN. Type OK to continue:");
        if (!okText.Equals("OK", StringComparison.Ordinal)) return new WatcherResult(true);

        HttpClient httpClient = new();
        List<string> masterVersions = [];
        Dictionary<string, byte[]> masterVersionsFound = [];

        var serverTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        var serverTime = DateTimeOffset.UtcNow.Add(serverTimeZone.BaseUtcOffset);
        var startDate = serverTime.AddMinutes(-30);

        while (startDate <= serverTime)
        {
            string masterVersion = $"{serverTime.Year}{startDate.Month:D2}{startDate.Day:D2}{startDate.Hour:D2}{startDate.Minute:D2}{startDate.Second:D2}";
            masterVersions.Add(masterVersion);
            startDate = startDate.AddSeconds(1);
        }

        List<List<string>> batches = [];
        for (int i = 0; i < masterVersions.Count; i += _batchSize)
        {
            List<string> batch = masterVersions.SkipLast(i).TakeLast(_batchSize).ToList();
            batches.Add(batch);
        }

        ProgressBar progressBar = new() { MaxValue = masterVersions.Count, UnitOfMeasurement = string.Empty, LabelText = "Checking" };
        progressBar.Display();

        CancellationTokenSource cancellationTokenSource = new();
        foreach (var batch in batches)
        {
            var tasks = batch.Select(x => DownloadContentAsync(x, cancellationTokenSource.Token));
            await Task.WhenAll(tasks);
        }
        progressBar.Close();

        foreach (var masterVersion in masterVersionsFound)
        {
            WriteLineWithTimestamp(masterVersion.Key);
            await File.WriteAllBytesAsync(Path.Combine(Constants.DatabasePath, "bin", $"{masterVersion.Key}.bin.e"), masterVersion.Value);
        }

        return new WatcherResult(masterVersionsFound.Count > 0);

        async Task DownloadContentAsync(string masterVersion, CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken.IsCancellationRequested) return;

                HttpResponseMessage res = await httpClient.GetAsync(Config.Api.MakeMasterDataUrl($"prd-us/{masterVersion}"), cancellationToken);

                if (res.IsSuccessStatusCode && res.Content?.Headers?.ContentLength > 4096)
                {
                    masterVersionsFound.Add(masterVersion, await res.Content.ReadAsByteArrayAsync(cancellationToken));
                    cancellationTokenSource.Cancel();
                }

                lock (_lockObj)
                {
                    progressBar.Value++;
                }
            }
            catch
            {
                // Re-try
                await DownloadContentAsync(masterVersion, cancellationToken);
            }
        }
    }
}

public class MasterDatabaseWatcherMenuCommandArg
{
}
