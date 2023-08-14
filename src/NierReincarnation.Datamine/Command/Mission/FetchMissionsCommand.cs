using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchMissionsCommand : AbstractDbQueryCommand<FetchMissionsCommandArg, List<Mission>>
{
    public override Task<List<Mission>> ExecuteAsync(FetchMissionsCommandArg arg)
    {
        if (!arg.IsValid()) return Task.FromResult<List<Mission>>(null);

        var darkMissionGroup = arg.Entity ?? MasterDb.EntityMMissionGroupTable.FindByMissionGroupId(arg.EntityId);
        if (darkMissionGroup == null) return Task.FromResult<List<Mission>>(null);

        List<Mission> missions = new();

        foreach (var darkMission in MasterDb.EntityMMissionTable.All.Where(x => x.MissionGroupId == darkMissionGroup.MissionGroupId).OrderBy(x => x.SortOrderInMissionGroup))
        {
            var darkMissionTerm = MasterDb.EntityMMissionTermTable.FindByMissionTermId(darkMission.MissionTermId);

            if (arg.FromDate > CalculatorDateTime.FromUnixTime(darkMissionTerm.StartDatetime)) continue;
            if (arg.ToDate < CalculatorDateTime.FromUnixTime(darkMissionTerm.StartDatetime)) continue;

            var darkMissionReward = MasterDb.EntityMMissionRewardTable.FindByMissionRewardId(darkMission.MissionRewardId);

            missions.Add(new Mission
            {
                Name = $"mission.name.{darkMission.NameMissionTextId}".Localize(),
                StartDateTimeOffset = CalculatorDateTime.FromUnixTime(darkMissionTerm.StartDatetime),
                EndDateTimeOffset = CalculatorDateTime.FromUnixTime(darkMissionTerm.EndDatetime),
                Reward = new Reward
                {
                    Name = CalculatorPossession.GetItemName(darkMissionReward.PossessionType, darkMissionReward.PossessionId),
                    Count = darkMissionReward.Count
                }
            });
        }

        return Task.FromResult(missions);
    }
}

public class FetchMissionsCommandArg : AbstractEntityCommandWithDatesArg<EntityMMissionGroup>
{ }
