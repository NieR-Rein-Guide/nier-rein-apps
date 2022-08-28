using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_shop_item_cell_limited_open")]
    public class EntityMShopItemCellLimitedOpen
    {
        [Key(0)]
        public int ShopItemCellId { get; set; } // 0x10
        [Key(1)]
        public int LimitedOpenId { get; set; } // 0x14
    }
}