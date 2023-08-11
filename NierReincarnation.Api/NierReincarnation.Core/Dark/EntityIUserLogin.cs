using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_login")]
    public class EntityIUserLogin
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public int TotalLoginCount { get; set; }

        [Key(2)]
        public int ContinualLoginCount { get; set; }

        [Key(3)]
        public int MaxContinualLoginCount { get; set; }

        [Key(4)]
        public long LastLoginDatetime { get; set; }

        [Key(5)]
        public long LastComebackLoginDatetime { get; set; }

        [Key(6)]
        public long LatestVersion { get; set; }
    }
}
