using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_enhanced")]
    public class EntityMCostumeEnhanced
    {
        [Key(0)] // RVA: 0x1DF00E4 Offset: 0x1DF00E4 VA: 0x1DF00E4
        public int CostumeEnhancedId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DF0124 Offset: 0x1DF0124 VA: 0x1DF0124
        public int CostumeId { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DF0138 Offset: 0x1DF0138 VA: 0x1DF0138
        public int LimitBreakCount { get; set; } // 0x18
        [Key(3)] // RVA: 0x1DF014C Offset: 0x1DF014C VA: 0x1DF014C
        public int Level { get; set; } // 0x1C
        [Key(4)] // RVA: 0x1DF0160 Offset: 0x1DF0160 VA: 0x1DF0160
        public int ActiveSkillLevel { get; set; } // 0x20
        [Key(5)] // RVA: 0x1F77310 Offset: 0x1F77310 VA: 0x1F77310
        public int AwakenCount { get; set; } // 0x24
    }
}
