using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_important_item_effect_drop_count")]
    public class EntityMImportantItemEffectDropCount
    {
        [Key(0)]
        public int ImportantItemEffectDropCountId { get; set; } // 0x10

        [Key(1)]
        public int CountPermil { get; set; } // 0x14

        [Key(2)]
        public int ImportantItemEffectTargetQuestGroupId { get; set; } // 0x18

        [Key(3)]
        public int ImportantItemEffectTargetItemGroupId { get; set; } // 0x1C
    }
}
