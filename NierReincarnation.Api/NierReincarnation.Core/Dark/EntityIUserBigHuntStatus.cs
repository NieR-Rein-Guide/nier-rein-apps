using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_big_hunt_status")]
    public class EntityIUserBigHuntStatus
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int BigHuntBossQuestId { get; set; } // 0x18

        [Key(2)]
        public int DailyChallengeCount { get; set; } // 0x1C

        [Key(3)]
        public long LatestChallengeDatetime { get; set; } // 0x20

        [Key(4)]
        public long LatestVersion { get; set; } // 0x28
    }
}
