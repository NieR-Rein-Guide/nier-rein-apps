using NierReincarnation.Core.Dark.Localization;

namespace NierReincarnation.Datamine.Command;

public class ExportMissionsMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override Task ExecuteAsync()
    {
        foreach (var group in MasterDb.EntityMMissionGroupTable.All.OrderBy(x => x.SortOrderInLabel))
        {
            Console.WriteLine($"mission.label.{group.LabelMissionTextId}".Localize());
            foreach (var item in MasterDb.EntityMMissionTable.All.Where(x => x.MissionGroupId == group.MissionGroupId).OrderBy(x => x.SortOrderInMissionGroup))
            {
                Console.WriteLine($"mission.name.{item.NameMissionTextId}".Localize());
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();

        return Task.CompletedTask;
    }
}
