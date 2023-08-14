using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCostumeAwakenPriceGroupTable : TableBase<EntityMCostumeAwakenPriceGroup>
{
    private readonly Func<EntityMCostumeAwakenPriceGroup, (int, int)> primaryIndexSelector;

    public EntityMCostumeAwakenPriceGroupTable(EntityMCostumeAwakenPriceGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CostumeAwakenPriceGroupId, element.AwakenStepLowerLimit);
    }

    public RangeView<EntityMCostumeAwakenPriceGroup> FindRangeByCostumeAwakenPriceGroupIdAndAwakenStepLowerLimit(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
}
