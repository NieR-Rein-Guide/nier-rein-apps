using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportMissionPassMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override async Task ExecuteAsync()
    {
        foreach (var darkMissionPass in MasterDb.EntityMMissionPassTable.All
            .Where(x => DateTimeExtensions.IsCurrentOrFuture(x.StartDatetime, x.EndDatetime))
            .OrderBy(x => x.StartDatetime))
        {
            Console.WriteLine($"Mission Pass ({darkMissionPass.ToFormattedDateStr()})".ToHeader3());

            //var premiumItem = MasterDb.EntityMPremiumItemTable.All.FirstOrDefault(x => x.PremiumItemId == darkMissionPass.PremiumItemId);

            var darkMissionPassMissionGroups = MasterDb.EntityMMissionPassMissionGroupTable.FindByMissionPassId(darkMissionPass.MissionPassId);
            var darkMissionPassRewardGroups = MasterDb.EntityMMissionPassRewardGroupTable.FindByMissionPassRewardGroupId(darkMissionPass.MissionPassRewardGroupId);

            foreach (var darkMissionPassRewardGroupGroup in darkMissionPassRewardGroups.OrderBy(x => x.Level).GroupBy(x => x.Level))
            {
                var darkMissionPassLevelGroup = MasterDb.EntityMMissionPassLevelGroupTable.FindByMissionPassLevelGroupIdAndLevel((darkMissionPass.MissionPassLevelGroupId, darkMissionPassRewardGroupGroup.First().Level));
                Console.WriteLine($"Lv.{darkMissionPassLevelGroup.Level} ({darkMissionPassLevelGroup.NecessaryPoint})");

                foreach (var darkMissionPassRewardGroup in darkMissionPassRewardGroupGroup.OrderBy(x => x.IsPremium ? "B" : "A"))
                {
                    var prefix = darkMissionPassRewardGroup.IsPremium ? "($) " : string.Empty;
                    var rewardStr = CalculatorPossession.GetItemName(darkMissionPassRewardGroup.PossessionType, darkMissionPassRewardGroup.PossessionId);
                    Console.WriteLine($"{prefix}{rewardStr} x{darkMissionPassRewardGroup.Count}".ToListItem());
                }
            }
            Console.WriteLine();

            foreach (var darkMissionPassMissionGroup in darkMissionPassMissionGroups)
            {
                var darkMissionGroup = MasterDb.EntityMMissionGroupTable.FindByMissionGroupId(darkMissionPassMissionGroup.MissionGroupId);
                var missionGroup = await new FetchMissionGroupCommand().ExecuteAsync(new FetchMissionGroupCommandArg
                {
                    Entity = darkMissionGroup
                });

                Console.WriteLine($"{missionGroup.Name}".ToBold());
                foreach (var mission in missionGroup.Missions)
                {
                    Console.WriteLine($"{mission.Name} -> {mission.Reward}");
                }
                Console.WriteLine();
            }
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}
