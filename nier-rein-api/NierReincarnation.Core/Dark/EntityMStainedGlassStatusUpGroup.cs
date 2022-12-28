using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_stained_glass_status_up_group")]
    public class EntityMStainedGlassStatusUpGroup
    {
        [Key(0)]
        public int StainedGlassStatusUpGroupId { get; set; } // 0x10
        [Key(1)]
        public int GroupIndex { get; set; } // 0x14
        [Key(2)]
        public StatusKindType StatusKindType { get; set; } // 0x18
        [Key(3)]
        public StatusCalculationType StatusCalculationType { get; set; } // 0x1C
        [Key(4)]
        public int EffectValue { get; set; } // 0x20
    }
}