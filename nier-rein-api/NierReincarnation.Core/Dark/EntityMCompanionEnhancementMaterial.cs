using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_companion_enhancement_material")]
    public class EntityMCompanionEnhancementMaterial
    {
        [Key(0)]
        public int CompanionCategoryType { get; set; } // 0x10
        [Key(1)]
        public int Level { get; set; } // 0x14
        [Key(2)]
        public int MaterialId { get; set; } // 0x18
        [Key(3)]
        public int Count { get; set; } // 0x1C
        [Key(4)]
        public int SortOrder { get; set; } // 0x20
    }
}