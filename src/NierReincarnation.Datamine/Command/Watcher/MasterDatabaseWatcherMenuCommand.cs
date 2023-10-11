﻿using DustInTheWind.ConsoleTools.Controls.Spinners;
using NierReincarnation.Core.Dark.EntryPoint;

namespace NierReincarnation.Datamine.Command;

public class MasterDatabaseWatcherMenuCommand : AbstractWatcherMenuCommand<MasterDatabaseWatcherMenuCommandArg, WatcherResult>
{
    private static readonly object _lockObj = new();

    private static readonly int[] _hours = { 1, 2, 3, 4, 5, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 };

    private const int _batchSize = 10000;

    public override bool IsActive => Program.AppSettings.IsSetup && System.Diagnostics.Debugger.IsAttached;

    public override bool Reset => false;

    public override bool Login => false;

    public override bool UseLocalizations => false;

    public override int Revision => Program.AppSettings.DbRevision;

    public override TimeSpan Interval => TimeSpan.FromMinutes(10);

    public MasterDatabaseWatcherMenuCommand(MasterDatabaseWatcherMenuCommandArg arg) : base(arg)
    {
    }

    public override async Task<WatcherResult> ExecuteAsync(MasterDatabaseWatcherMenuCommandArg arg)
    {
        HttpClient httpClient = new();
        List<string> masterVersions = new();
        List<string> masterVersionsFound = new();

        var serverTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        var serverTime = DateTimeOffset.UtcNow.Add(serverTimeZone.BaseUtcOffset);
        var prev3Days = serverTime.AddDays(-3);
        var next3Days = serverTime.AddDays(1);

        int[] months = new[] { prev3Days.Month, next3Days.Month }.Distinct().ToArray();

        Dictionary<int, int[]> days = new();

        if (months.Length == 2)
        {
            days.Add(months[0], Enumerable.Range(prev3Days.Day, DateTime.DaysInMonth(serverTime.Year, months[0]) - prev3Days.Day + 1).ToArray());
            days.Add(months[1], Enumerable.Range(1, next3Days.Day).ToArray());
        }
        else
        {
            days.Add(months[0], Enumerable.Range(prev3Days.Day, next3Days.Day - prev3Days.Day + 1).ToArray());
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
                            string masterVersion = $"prd-us/{serverTime.Year}{month:D2}{days[month][dayIndex]:D2}{_hours[hourIndex]:D2}{minute:D2}{second:D2}";
                            masterVersions.Add(masterVersion);
                        }
                    }
                }
            }
        }

        List<List<string>> batches = new();
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
            WriteLineWithTimestamp(masterVersion);
        }

        return new WatcherResult(masterVersionsFound.Count > 0);

        async Task DownloadContentAsync(string masterVersion, CancellationToken cancellationToken)
        {
            try
            {
                if (cancellationToken.IsCancellationRequested) return;

                HttpResponseMessage res = await httpClient.GetAsync(Config.Api.MakeMasterDataUrl(masterVersion), cancellationToken);

                if (res.IsSuccessStatusCode && res.Content?.Headers?.ContentLength > 4096)
                {
                    masterVersionsFound.Add(masterVersion);
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
