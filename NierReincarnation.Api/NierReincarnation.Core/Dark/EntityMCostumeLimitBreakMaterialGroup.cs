using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_limit_break_material_group")]
    public class EntityMCostumeLimitBreakMaterialGroup
    {
        [Key(0)]
        public int CostumeLimitBreakMaterialGroupId { get; set; } // 0x10
        [Key(1)]
        public int MaterialId { get; set; } // 0x14
        [Key(2)]
        public int Count { get; set; } // 0x18
        [Key(3)]
        public int SortOrder { get; set; } // 0x1C
        [Key(4)]
        public int CostumeOverflowExchangePossessionGroupId { get; set; } // 0x20
    }
}