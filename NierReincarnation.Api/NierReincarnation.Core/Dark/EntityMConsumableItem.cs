using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_consumable_item")]
    public class EntityMConsumableItem
    {
        [Key(0)] // RVA: 0x1DEF3AC Offset: 0x1DEF3AC VA: 0x1DEF3AC
        public int ConsumableItemId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DEF3EC Offset: 0x1DEF3EC VA: 0x1DEF3EC
        public ConsumableItemType ConsumableItemType { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DEF400 Offset: 0x1DEF400 VA: 0x1DEF400
        public int SortOrder { get; set; } // 0x18
        [Key(3)] // RVA: 0x1DEF414 Offset: 0x1DEF414 VA: 0x1DEF414
        public int SellPrice { get; set; } // 0x1C
        [Key(4)] // RVA: 0x1DEF428 Offset: 0x1DEF428 VA: 0x1DEF428
        public int ConsumableItemTermId { get; set; } // 0x20
        [Key(5)] // RVA: 0x1DEF43C Offset: 0x1DEF43C VA: 0x1DEF43C
        public string AssetName { get; set; } // 0x28
        [Key(6)] // RVA: 0x1DEF450 Offset: 0x1DEF450 VA: 0x1DEF450
        public int AssetCategoryId { get; set; } // 0x30
        [Key(7)] // RVA: 0x1DEF464 Offset: 0x1DEF464 VA: 0x1DEF464
        public int AssetVariationId { get; set; } // 0x34
	}
}
