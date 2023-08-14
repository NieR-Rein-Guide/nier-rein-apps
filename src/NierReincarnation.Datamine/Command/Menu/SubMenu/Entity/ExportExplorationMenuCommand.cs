using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportExplorationMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override Task ExecuteAsync()
    {
        foreach (var explore in MasterDb.EntityMExploreTable.All)
        {
            var exploreGroup = MasterDb.EntityMExploreGroupTable.FindByExploreId(explore.ExploreId)[0];
            var exploreNameStr = $"search.minigame.name.{explore.ExploreId:00}".Localize();

            Console.WriteLine($"{exploreNameStr} - {exploreGroup.DifficultyType.ToFormattedStr()} ({explore.StartDatetime.ToFormattedDate()})");
        }

        Console.WriteLine();
        Console.WriteLine();

        return Task.CompletedTask;
    }
}
