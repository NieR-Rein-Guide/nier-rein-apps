using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_shop_item_cell_term")]
    public class EntityMShopItemCellTerm
    {
        [Key(0)] // RVA: 0x1DDFD54 Offset: 0x1DDFD54 VA: 0x1DDFD54
        public int ShopItemCellTermId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DDFD94 Offset: 0x1DDFD94 VA: 0x1DDFD94
        public long StartDatetime { get; set; } // 0x18

        [Key(2)] // RVA: 0x1DDFDA8 Offset: 0x1DDFDA8 VA: 0x1DDFDA8
        public long EndDatetime { get; set; } // 0x20
    }
}
