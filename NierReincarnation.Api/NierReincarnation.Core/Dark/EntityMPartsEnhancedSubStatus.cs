using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_parts_enhanced_sub_status")]
    public class EntityMPartsEnhancedSubStatus
    {
        [Key(0)]
        public int PartsEnhancedId { get; set; } // 0x10

        [Key(1)]
        public int StatusIndex { get; set; } // 0x14

        [Key(2)]
        public int PartsStatusSubLotteryId { get; set; } // 0x18

        [Key(3)]
        public int Level { get; set; } // 0x1C

        [Key(4)]
        public StatusKindType StatusKindType { get; set; } // 0x20

        [Key(5)]
        public StatusCalculationType StatusCalculationType { get; set; } // 0x24

        [Key(6)]
        public int FixedStatusChangeValue { get; set; } // 0x28
    }
}
