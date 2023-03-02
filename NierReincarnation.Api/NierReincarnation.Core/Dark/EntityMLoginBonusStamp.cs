using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_login_bonus_stamp")]
    public class EntityMLoginBonusStamp
    {
        [Key(0)]
        public int LoginBonusId { get; set; } // 0x10
        [Key(1)]
        public int LowerPageNumber { get; set; } // 0x14
        [Key(2)]
        public int StampNumber { get; set; } // 0x18
        [Key(3)]
        public int RewardPossessionType { get; set; } // 0x1C
        [Key(4)]
        public int RewardPossessionId { get; set; } // 0x20
        [Key(5)]
        public int RewardCount { get; set; } // 0x24
    }
}