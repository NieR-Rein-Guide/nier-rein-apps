using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMMissionRewardTable : TableBase<EntityMMissionReward>
{
    private readonly Func<EntityMMissionReward, int> primaryIndexSelector;

    public EntityMMissionRewardTable(EntityMMissionReward[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.MissionRewardId;
    }

    public EntityMMissionReward FindByMissionRewardId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
