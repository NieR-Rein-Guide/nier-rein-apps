using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMShopItemLimitedStockTable : TableBase<EntityMShopItemLimitedStock>
{
    private readonly Func<EntityMShopItemLimitedStock, int> primaryIndexSelector;

    public EntityMShopItemLimitedStockTable(EntityMShopItemLimitedStock[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.ShopItemLimitedStockId;
    }

    public EntityMShopItemLimitedStock FindByShopItemLimitedStockId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
