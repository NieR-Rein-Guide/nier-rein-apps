using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCageOrnamentRewardTable : TableBase<EntityMCageOrnamentReward>
{
    private readonly Func<EntityMCageOrnamentReward, (int, PossessionType, int)> primaryIndexSelector;

    public EntityMCageOrnamentRewardTable(EntityMCageOrnamentReward[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CageOrnamentRewardId, element.PossessionType, element.PossessionId);
    }
}
