using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserEventQuestDailyGroupCompleteRewardTable : TableBase<EntityIUserEventQuestDailyGroupCompleteReward>
{
    private readonly Func<EntityIUserEventQuestDailyGroupCompleteReward, long> primaryIndexSelector;

    public EntityIUserEventQuestDailyGroupCompleteRewardTable(EntityIUserEventQuestDailyGroupCompleteReward[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.UserId;
    }

    public bool TryFindByUserId(long key, out EntityIUserEventQuestDailyGroupCompleteReward result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key, out result);
}
