using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_parts")]
    public class EntityMParts
    {
        [Key(0)] // RVA: 0x1DE0138 Offset: 0x1DE0138 VA: 0x1DE0138
        public int PartsId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DE0178 Offset: 0x1DE0178 VA: 0x1DE0178
        public RarityType RarityType { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DE018C Offset: 0x1DE018C VA: 0x1DE018C
        public int PartsGroupId { get; set; } // 0x18

        [Key(3)] // RVA: 0x1DE01A0 Offset: 0x1DE01A0 VA: 0x1DE01A0
        public int PartsStatusMainLotteryGroupId { get; set; } // 0x1C

        [Key(4)] // RVA: 0x1DE01B4 Offset: 0x1DE01B4 VA: 0x1DE01B4
        public int PartsStatusSubLotteryGroupId { get; set; } // 0x20

        [Key(5)] // RVA: 0x1DE01C8 Offset: 0x1DE01C8 VA: 0x1DE01C8
        public int PartsInitialLotteryId { get; set; } // 0x24
    }
}
