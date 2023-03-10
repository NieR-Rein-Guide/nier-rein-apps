using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_movie")]
    public class EntityIUserMovie
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10
        [Key(1)]
        public int MovieId { get; set; } // 0x18
        [Key(2)]
        public long LatestViewedDatetime { get; set; } // 0x20
        [Key(3)]
        public long LatestVersion { get; set; } // 0x28
    }
}