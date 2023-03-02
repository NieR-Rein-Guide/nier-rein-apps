using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_big_hunt_progress_status")]
    public class EntityIUserBigHuntProgressStatus
    {
        [Key(0)] // RVA: 0x1DE469C Offset: 0x1DE469C VA: 0x1DE469C
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE46DC Offset: 0x1DE46DC VA: 0x1DE46DC
        public int CurrentBigHuntBossQuestId { get; set; }
        [Key(2)] // RVA: 0x1DE46F0 Offset: 0x1DE46F0 VA: 0x1DE46F0
        public int CurrentBigHuntQuestId { get; set; }
        [Key(3)] // RVA: 0x1DE4704 Offset: 0x1DE4704 VA: 0x1DE4704
        public int CurrentQuestSceneId { get; set; }
        [Key(4)] // RVA: 0x1DE4718 Offset: 0x1DE4718 VA: 0x1DE4718
        public bool IsDryRun { get; set; }
        [Key(5)] // RVA: 0x1DE472C Offset: 0x1DE472C VA: 0x1DE472C
        public long LatestVersion { get; set; }
	}
}
