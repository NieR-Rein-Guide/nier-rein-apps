using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_big_hunt_status")]
    public class EntityIUserBigHuntStatus
    {
        [Key(0)] // RVA: 0x1DE4740 Offset: 0x1DE4740 VA: 0x1DE4740
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE4780 Offset: 0x1DE4780 VA: 0x1DE4780
        public int BigHuntBossQuestId { get; set; }
        [Key(2)] // RVA: 0x1DE47C0 Offset: 0x1DE47C0 VA: 0x1DE47C0
        public int DailyChallengeCount { get; set; }
        [Key(3)] // RVA: 0x1DE47D4 Offset: 0x1DE47D4 VA: 0x1DE47D4
        public long LatestChallengeDatetime { get; set; }
        [Key(4)] // RVA: 0x1DE47E8 Offset: 0x1DE47E8 VA: 0x1DE47E8
        public long LatestVersion { get; set; }
	}
}
