using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user")]
    public class EntityIUser
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public long PlayerId { get; set; } // 0x18

        [Key(2)]
        public int OsType { get; set; } // 0x20

        [Key(3)]
        public PlatformType PlatformType { get; set; } // 0x24

        [Key(4)]
        public int UserRestrictionType { get; set; } // 0x28

        [Key(5)]
        public long RegisterDatetime { get; set; } // 0x30

        [Key(6)]
        public long GameStartDatetime { get; set; } // 0x38

        [Key(7)]
        public long LatestVersion { get; set; } // 0x40
    }
}
