using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_parts_enhanced")]
    public class EntityMPartsEnhanced
    {
        [Key(0)] // RVA: 0x1DF3C20 Offset: 0x1DF3C20 VA: 0x1DF3C20
        public int PartsEnhancedId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DF3C60 Offset: 0x1DF3C60 VA: 0x1DF3C60
        public int PartsId { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DF3C74 Offset: 0x1DF3C74 VA: 0x1DF3C74
        public int PartsStatusMainId { get; set; } // 0x18

        [Key(3)] // RVA: 0x1DF3C88 Offset: 0x1DF3C88 VA: 0x1DF3C88
        public int Level { get; set; } // 0x1C

        [Key(4)] // RVA: 0x1DF3C9C Offset: 0x1DF3C9C VA: 0x1DF3C9C
        public bool IsRandomSubStatusCount { get; set; } // 0x20

        [Key(5)] // RVA: 0x1DF3CB0 Offset: 0x1DF3CB0 VA: 0x1DF3CB0
        public int SubStatusCount { get; set; } // 0x24
    }
}
