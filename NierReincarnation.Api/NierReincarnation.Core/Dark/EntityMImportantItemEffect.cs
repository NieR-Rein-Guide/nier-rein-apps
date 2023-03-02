using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_important_item_effect")]
    public class EntityMImportantItemEffect
    {
        [Key(0)]
        public int ImportantItemEffectId { get; set; } // 0x10
        [Key(1)]
        public int ImportantItemEffectGroupingId { get; set; } // 0x14
        [Key(2)]
        public int Priority { get; set; } // 0x18
        [Key(3)]
        public int ImportantItemEffectType { get; set; } // 0x1C
        [Key(4)]
        public int ImportantItemEffectTargetId { get; set; } // 0x20
        [Key(5)]
        public long StartDatetime { get; set; } // 0x28
        [Key(6)]
        public long EndDatetime { get; set; } // 0x30
    }
}