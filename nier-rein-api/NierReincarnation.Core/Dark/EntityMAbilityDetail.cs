using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_ability_detail")]
    public class EntityMAbilityDetail
    {
        [Key(0)] // RVA: 0x1DD6500 Offset: 0x1DD6500 VA: 0x1DD6500
        public int AbilityDetailId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DD6540 Offset: 0x1DD6540 VA: 0x1DD6540
        public int NameAbilityTextId { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DD6554 Offset: 0x1DD6554 VA: 0x1DD6554
        public int DescriptionAbilityTextId { get; set; } // 0x18
        [Key(3)] // RVA: 0x1DD6568 Offset: 0x1DD6568 VA: 0x1DD6568
        public int AbilityBehaviourGroupId { get; set; } // 0x1C
        [Key(4)] // RVA: 0x1DD657C Offset: 0x1DD657C VA: 0x1DD657C
        public int AssetCategoryId { get; set; } // 0x20
        [Key(5)] // RVA: 0x1DD6590 Offset: 0x1DD6590 VA: 0x1DD6590
        public int AssetVariationId { get; set; } // 0x24
	}
}
