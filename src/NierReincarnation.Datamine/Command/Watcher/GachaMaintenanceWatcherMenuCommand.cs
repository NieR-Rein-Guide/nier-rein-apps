using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class GachaMaintenanceWatcherMenuCommand : AbstractWatcherMenuCommand<RevisionWatcherMenuCommandArg, WatcherResult>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override bool Reset => true;

    public override int Revision => Program.AppSettings.DbRevision;

    public GachaMaintenanceWatcherMenuCommand(RevisionWatcherMenuCommandArg arg) : base(arg)
    {
    }

    public override async Task<WatcherResult> ExecuteAsync(RevisionWatcherMenuCommandArg arg)
    {
        var maintenances = await new FetchAllMaintenancesCommand().ExecuteAsync(new FetchAllMaintenancesCommandArg
        {
            IsCurrentOrFuture = true,
            TypeFilters = new[] { MaintenanceBlockFunctionType.GACHA, MaintenanceBlockFunctionType.REWARD_GACHA }
        });

        if (maintenances.Count > 0)
        {
            foreach (var maintenance in maintenances)
            {
                WriteLineWithTimestamp($"{maintenance.Type.ToFormattedStr()} ({maintenance.StartDateTimeOffset.ToFormattedDate()} ~ {maintenance.EndDateTimeOffset.ToFormattedDate()})");

                if (maintenance.Type == MaintenanceBlockFunctionType.GACHA)
                {
                    foreach (var affectedEntity in maintenance.AffectedEntities)
                    {
                        Console.WriteLine(GetGachaName(affectedEntity).ToListItem());
                    }
                }
            }

            return new WatcherResult(true);
        }
        else
        {
            WriteLineWithTimestamp("No upcoming maintenance");
            return new WatcherResult(false);
        }
    }

    private static string GetGachaName(string gachaId)
    {
        string gachaName = $"gacha.title.limited_{gachaId}".Localize();

        if (string.IsNullOrEmpty(gachaName))
        {
            gachaName = $"gacha.title.step_up_{gachaId}".Localize();
        }

        if (string.IsNullOrEmpty(gachaName))
        {
            gachaName = $"Unknown banner ID: {gachaId}";
        }

        return gachaName;
    }
}

public class GachaMaintenanceWatcherMenuCommandArg
{
}
