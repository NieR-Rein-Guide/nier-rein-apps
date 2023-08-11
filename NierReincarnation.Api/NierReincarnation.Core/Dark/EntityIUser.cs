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
        public long UserId { get; set; }

        [Key(1)]
        public long PlayerId { get; set; }

        [Key(2)]
        public int OsType { get; set; }

        [Key(3)]
        public PlatformType PlatformType { get; set; }

        [Key(4)]
        public int UserRestrictionType { get; set; }

        [Key(5)]
        public long RegisterDatetime { get; set; }

        [Key(6)]
        public long GameStartDatetime { get; set; }

        [Key(7)]
        public long LatestVersion { get; set; }
    }
}
