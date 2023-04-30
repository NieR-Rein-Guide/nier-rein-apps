using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_big_hunt_max_score")]
    public class EntityIUserBigHuntMaxScore
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int BigHuntBossId { get; set; } // 0x18

        [Key(2)]
        public long MaxScore { get; set; } // 0x20

        [Key(3)]
        public long MaxScoreUpdateDatetime { get; set; } // 0x28

        [Key(4)]
        public long LatestVersion { get; set; } // 0x30
    }
}
