using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_shop_item_cell_group")]
    public class EntityMShopItemCellGroup
    {
        [Key(0)] // RVA: 0x1DDFCAC Offset: 0x1DDFCAC VA: 0x1DDFCAC
        public int ShopItemCellGroupId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DDFCEC Offset: 0x1DDFCEC VA: 0x1DDFCEC
        public int ShopItemCellId { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DDFD2C Offset: 0x1DDFD2C VA: 0x1DDFD2C
        public int SortOrder { get; set; } // 0x18

        [Key(3)] // RVA: 0x1DDFD40 Offset: 0x1DDFD40 VA: 0x1DDFD40
        public int ShopItemCellTermId { get; set; } // 0x1C
    }
}
