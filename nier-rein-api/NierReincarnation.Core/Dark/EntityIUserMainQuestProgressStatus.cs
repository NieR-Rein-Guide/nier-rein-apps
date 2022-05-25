using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_main_quest_progress_status")]
    public class EntityIUserMainQuestProgressStatus
    {
        [Key(0)] // RVA: 0x1DE65F8 Offset: 0x1DE65F8 VA: 0x1DE65F8
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1DE6638 Offset: 0x1DE6638 VA: 0x1DE6638
        public int CurrentQuestSceneId { get; set; }
        [Key(2)] // RVA: 0x1DE664C Offset: 0x1DE664C VA: 0x1DE664C
        public int HeadQuestSceneId { get; set; }
        [Key(3)] // RVA: 0x1DE6660 Offset: 0x1DE6660 VA: 0x1DE6660
        public int CurrentQuestFlowType { get; set; }
        [Key(4)] // RVA: 0x1DE6674 Offset: 0x1DE6674 VA: 0x1DE6674
        public long LatestVersion { get; set; }
	}
}
