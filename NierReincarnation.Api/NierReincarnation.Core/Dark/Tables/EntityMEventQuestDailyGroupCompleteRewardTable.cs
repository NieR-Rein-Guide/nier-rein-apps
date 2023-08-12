using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMEventQuestDailyGroupCompleteRewardTable : TableBase<EntityMEventQuestDailyGroupCompleteReward>
{
    private readonly Func<EntityMEventQuestDailyGroupCompleteReward, (int, int)> primaryIndexSelector;

    public EntityMEventQuestDailyGroupCompleteRewardTable(EntityMEventQuestDailyGroupCompleteReward[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.EventQuestDailyGroupCompleteRewardId, element.SortOrder);
    }
}
