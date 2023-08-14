using NierReincarnation.Datamine.Model;

namespace NierReincarnation.Datamine.Command;

public class FetchAllMissionGroupsCommand : AbstractDbQueryCommand<FetchAllMissionGroupsCommandArg, List<MissionGroup>>
{
    public override async Task<List<MissionGroup>> ExecuteAsync(FetchAllMissionGroupsCommandArg arg)
    {
        List<MissionGroup> missionGroups = new();
        foreach (var darkMissionGroup in MasterDb.EntityMMissionGroupTable.All)
        {
            var missionGroup = await new FetchMissionGroupCommand().ExecuteAsync(new FetchMissionGroupCommandArg
            {
                Entity = darkMissionGroup,
                IncludeMissions = arg.IncludeMissions,
                IncludeEmptyMissionGroups = arg.IncludeEmptyMissionGroups,
                FromDate = arg.FromDate,
                ToDate = arg.ToDate
            });

            if (missionGroup != null)
            {
                missionGroups.Add(missionGroup);
            }
        }
        return missionGroups;
    }
}

public class FetchAllMissionGroupsCommandArg : AbstractCommandWithDatesArg
{
    public bool IncludeMissions { get; init; } = true;

    public bool IncludeEmptyMissionGroups { get; init; }
}
