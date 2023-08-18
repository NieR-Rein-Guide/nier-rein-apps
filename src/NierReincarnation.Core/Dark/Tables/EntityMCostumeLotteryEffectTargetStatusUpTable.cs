using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCostumeLotteryEffectTargetStatusUpTable : TableBase<EntityMCostumeLotteryEffectTargetStatusUp>
{
    private readonly Func<EntityMCostumeLotteryEffectTargetStatusUp, (int, StatusKindType, StatusCalculationType)> primaryIndexSelector;
    private readonly Func<EntityMCostumeLotteryEffectTargetStatusUp, int> secondaryIndexSelector;

    public EntityMCostumeLotteryEffectTargetStatusUpTable(EntityMCostumeLotteryEffectTargetStatusUp[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CostumeLotteryEffectTargetStatusUpId, element.StatusKindType, element.StatusCalculationType);
        secondaryIndexSelector = element => element.CostumeLotteryEffectTargetStatusUpId;
    }

    public RangeView<EntityMCostumeLotteryEffectTargetStatusUp> FindByCostumeLotteryEffectTargetStatusUpId(int key) =>
        FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key);
}
