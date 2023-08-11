using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_big_hunt_status")]
    public class EntityIUserBigHuntStatus
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public int BigHuntBossQuestId { get; set; }

        [Key(2)]
        public int DailyChallengeCount { get; set; }

        [Key(3)]
        public long LatestChallengeDatetime { get; set; }

        [Key(4)]
        public long LatestVersion { get; set; }
    }
}
