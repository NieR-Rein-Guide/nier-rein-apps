using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_shop_item_limited_stock")]
    public class EntityMShopItemLimitedStock
    {
        [Key(0)] // RVA: 0x1DDFF74 Offset: 0x1DDFF74 VA: 0x1DDFF74
        public int ShopItemLimitedStockId { get; set; }
        [Key(1)] // RVA: 0x1DDFFB4 Offset: 0x1DDFFB4 VA: 0x1DDFFB4
        public int MaxCount { get; set; }
        [Key(2)] // RVA: 0x1DDFFC8 Offset: 0x1DDFFC8 VA: 0x1DDFFC8
        public int ShopItemAutoResetType { get; set; }
        [Key(3)] // RVA: 0x1DDFFDC Offset: 0x1DDFFDC VA: 0x1DDFFDC
        public int ShopItemAutoResetPeriod { get; set; }
	}
}
