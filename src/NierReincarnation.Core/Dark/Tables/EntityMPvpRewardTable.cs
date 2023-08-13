using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMPvpRewardTable : TableBase<EntityMPvpReward>
{
    private readonly Func<EntityMPvpReward, int> primaryIndexSelector;

    public EntityMPvpRewardTable(EntityMPvpReward[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.PvpRewardId;
    }

    public EntityMPvpReward FindByPvpRewardId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
