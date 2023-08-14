using NierReincarnation.Core.Dark;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchMissionGroupCommand : AbstractDbQueryCommand<FetchMissionGroupCommandArg, MissionGroup>
{
    public override async Task<MissionGroup> ExecuteAsync(FetchMissionGroupCommandArg arg)
    {
        if (!arg.IsValid()) return null;

        var darkMissionGroup = arg.Entity ?? MasterDb.EntityMMissionGroupTable.FindByMissionGroupId(arg.EntityId);

        if (darkMissionGroup == null) return null;

        var missions = arg.IncludeMissions
            ? await new FetchMissionsCommand().ExecuteAsync(new FetchMissionsCommandArg
            {
                Entity = darkMissionGroup,
                FromDate = arg.FromDate,
                ToDate = arg.ToDate
            })
            : new List<Mission>();

        if (!arg.IncludeEmptyMissionGroups && missions.Count == 0) return null;

        return new MissionGroup
        {
            Name = $"mission.label.{darkMissionGroup.LabelMissionTextId}".Localize(),
            StartDateTimeOffset = missions.Min(x => x.StartDateTimeOffset),
            EndDateTimeOffset = missions.Max(x => x.EndDateTimeOffset),
            Missions = missions
        };
    }
}

public class FetchMissionGroupCommandArg : AbstractEntityCommandWithDatesArg<EntityMMissionGroup>
{
    public bool IncludeMissions { get; init; } = true;

    public bool IncludeEmptyMissionGroups { get; init; }
}
