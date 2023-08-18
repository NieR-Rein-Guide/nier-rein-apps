using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCostumeLotteryEffectMaterialGroupTable : TableBase<EntityMCostumeLotteryEffectMaterialGroup>
{
    private readonly Func<EntityMCostumeLotteryEffectMaterialGroup, (int, int)> primaryIndexSelector;
    private readonly Func<EntityMCostumeLotteryEffectMaterialGroup, int> secondaryIndexSelector;

    public EntityMCostumeLotteryEffectMaterialGroupTable(EntityMCostumeLotteryEffectMaterialGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CostumeLotteryEffectMaterialGroupId, element.MaterialId);
        secondaryIndexSelector = element => element.CostumeLotteryEffectMaterialGroupId;
    }

    public RangeView<EntityMCostumeLotteryEffectMaterialGroup> FindByCostumeLotteryEffectMaterialGroupId(int key) =>
        FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key);
}
