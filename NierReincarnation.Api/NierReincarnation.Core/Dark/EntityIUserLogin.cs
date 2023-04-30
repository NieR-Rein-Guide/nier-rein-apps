using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_login")]
    public class EntityIUserLogin
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int TotalLoginCount { get; set; } // 0x18

        [Key(2)]
        public int ContinualLoginCount { get; set; } // 0x1C

        [Key(3)]
        public int MaxContinualLoginCount { get; set; } // 0x20

        [Key(4)]
        public long LastLoginDatetime { get; set; } // 0x28

        [Key(5)]
        public long LastComebackLoginDatetime { get; set; } // 0x30

        [Key(6)]
        public long LatestVersion { get; set; } // 0x38
    }
}
