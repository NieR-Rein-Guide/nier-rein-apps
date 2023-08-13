using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserMissionCompletionProgressTable : TableBase<EntityIUserMissionCompletionProgress>
{
    private readonly Func<EntityIUserMissionCompletionProgress, (long, int)> primaryIndexSelector;

    public EntityIUserMissionCompletionProgressTable(EntityIUserMissionCompletionProgress[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.MissionId);
    }
}
