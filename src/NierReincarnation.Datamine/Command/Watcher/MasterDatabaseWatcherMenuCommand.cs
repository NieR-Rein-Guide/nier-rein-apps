using DustInTheWind.ConsoleTools.Controls.InputControls;
using DustInTheWind.ConsoleTools.Controls.Spinners;
using NierReincarnation.Core.Dark.EntryPoint;

namespace NierReincarnation.Datamine.Command;

public class MasterDatabaseWatcherMenuCommand(MasterDatabaseWatcherMenuCommandArg arg) : AbstractWatcherMenuCommand<MasterDatabaseWatcherMenuCommandArg, WatcherResult>(arg)
{
    private static readonly object _lockObj = new();

    private static readonly int[] _hours = [/* 1, 2, 3, 4, 5, 14, */ 15, 16, 17, 18, 19, /* 20, 21, 22, 23 */];

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
        var twoDaysAgo = serverTime.AddDays(-2);

        int[] months = new[] { twoDaysAgo.Month, serverTime.Month }.Distinct().ToArray();

        Dictionary<int, int[]> days = [];

        if (months.Length == 2)
        {
            days.Add(months[0], Enumerable.Range(twoDaysAgo.Day, DateTime.DaysInMonth(serverTime.Year, months[0]) - twoDaysAgo.Day + 1).ToArray());
            days.Add(months[1], Enumerable.Range(1, serverTime.Day).ToArray());
        }
        else
        {
            days.Add(months[0], Enumerable.Range(twoDaysAgo.Day, serverTime.Day - twoDaysAgo.Day + 1).ToArray());
        }

        foreach (var month in months)
        {
            for (int dayIndex = 0; dayIndex < days[month].Length; dayIndex++)
            {
                for (int hourIndex = 0; hourIndex < _hours.Length; hourIndex++)
                {
                    for (int minute = 1; minute <= 60; minute++)
                    {
                        for (int second = 1; second <= 60; second++)
                        {
                            string masterVersion = $"{serverTime.Year}{month:D2}{days[month][dayIndex]:D2}{_hours[hourIndex]:D2}{minute:D2}{second:D2}";
                            masterVersions.Add(masterVersion);
                        }
                    }
                }
            }
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
