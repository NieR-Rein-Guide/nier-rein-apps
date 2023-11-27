using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMShopItemCellGroupTable : TableBase<EntityMShopItemCellGroup>
{
    private readonly Func<EntityMShopItemCellGroup, (int, int)> primaryIndexSelector;

    public EntityMShopItemCellGroupTable(EntityMShopItemCellGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.ShopItemCellGroupId, element.ShopItemCellId);
    }

    public RangeView<EntityMShopItemCellGroup> FindRangeByShopItemCellGroupIdAndShopItemCellId(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
}
