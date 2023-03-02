using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_event_quest_progress_status")]
    public class EntityIUserEventQuestProgressStatus
    {
        [Key(0)] // RVA: 0x1DE5904 Offset: 0x1DE5904 VA: 0x1DE5904
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE5944 Offset: 0x1DE5944 VA: 0x1DE5944
        public int CurrentEventQuestChapterId { get; set; }
        [Key(2)] // RVA: 0x1DE5958 Offset: 0x1DE5958 VA: 0x1DE5958
        public int CurrentQuestId { get; set; }
        [Key(3)] // RVA: 0x1DE596C Offset: 0x1DE596C VA: 0x1DE596C
        public int CurrentQuestSceneId { get; set; }
        [Key(4)] // RVA: 0x1DE5980 Offset: 0x1DE5980 VA: 0x1DE5980
        public int HeadQuestSceneId { get; set; }
        [Key(5)] // RVA: 0x1DE5994 Offset: 0x1DE5994 VA: 0x1DE5994
        public long LatestVersion { get; set; }
	}
}
