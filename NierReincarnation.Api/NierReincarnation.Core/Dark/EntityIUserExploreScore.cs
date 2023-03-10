using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_explore_score")]
    public class EntityIUserExploreScore
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10
        [Key(1)]
        public int ExploreId { get; set; } // 0x18
        [Key(2)]
        public int MaxScore { get; set; } // 0x1C
        [Key(3)]
        public long MaxScoreUpdateDatetime { get; set; } // 0x20
        [Key(4)]
        public long LatestVersion { get; set; } // 0x28
    }
}