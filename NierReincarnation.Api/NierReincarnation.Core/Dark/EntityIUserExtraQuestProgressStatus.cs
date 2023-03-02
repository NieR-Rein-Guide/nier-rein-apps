using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_extra_quest_progress_status")]
    public class EntityIUserExtraQuestProgressStatus
    {
        [Key(0)] // RVA: 0x1DE5B9C Offset: 0x1DE5B9C VA: 0x1DE5B9C
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE5BDC Offset: 0x1DE5BDC VA: 0x1DE5BDC
        public int CurrentQuestId { get; set; }
        [Key(2)] // RVA: 0x1DE5BF0 Offset: 0x1DE5BF0 VA: 0x1DE5BF0
        public int CurrentQuestSceneId { get; set; }
        [Key(3)] // RVA: 0x1DE5C04 Offset: 0x1DE5C04 VA: 0x1DE5C04
        public int HeadQuestSceneId { get; set; }
        [Key(4)] // RVA: 0x1DE5C18 Offset: 0x1DE5C18 VA: 0x1DE5C18
        public long LatestVersion { get; set; }
	}
}
