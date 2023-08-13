using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_shop_item_limited_stock")]
public class EntityMShopItemLimitedStock
{
    [Key(0)]
    public int ShopItemLimitedStockId { get; set; }

    [Key(1)]
    public int MaxCount { get; set; }

    [Key(2)]
    public AutoResetType ShopItemAutoResetType { get; set; }

    [Key(3)]
    public int ShopItemAutoResetPeriod { get; set; }
}
