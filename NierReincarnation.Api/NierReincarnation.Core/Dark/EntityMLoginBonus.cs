using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_login_bonus")]
    public class EntityMLoginBonus
    {
        [Key(0)]
        public int LoginBonusId { get; set; } // 0x10
        [Key(1)]
        public int SortOrder { get; set; } // 0x14
        [Key(2)]
        public int LoginBonusStartConditionId { get; set; } // 0x18
        [Key(3)]
        public int TotalPageCount { get; set; } // 0x1C
        [Key(4)]
        public long StartDatetime { get; set; } // 0x20
        [Key(5)]
        public long EndDatetime { get; set; } // 0x28
        [Key(6)]
        public long StampReceiveEndDatetime { get; set; } // 0x30
        [Key(7)]
        public string LoginBonusAssetName { get; set; } // 0x38
    }
}