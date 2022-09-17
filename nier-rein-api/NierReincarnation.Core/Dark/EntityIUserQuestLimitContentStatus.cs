using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    // LimitContentQuestStatusType == 1 is cleared

    [MessagePackObject]
    [MemoryTable("i_user_quest_limit_content_status")]
    public class EntityIUserQuestLimitContentStatus
    {
        [Key(0)] // RVA: 0x1F87098 Offset: 0x1F87098 VA: 0x1F87098
        public long UserId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1F870D8 Offset: 0x1F870D8 VA: 0x1F870D8
        public int QuestId { get; set; } // 0x18
        [Key(2)] // RVA: 0x1F87118 Offset: 0x1F87118 VA: 0x1F87118
        public int LimitContentQuestStatusType { get; set; } // 0x1C
        [Key(3)] // RVA: 0x1F8712C Offset: 0x1F8712C VA: 0x1F8712C
        public int EventQuestChapterId { get; set; } // 0x20
        [Key(4)] // RVA: 0x1F87180 Offset: 0x1F87180 VA: 0x1F87180
        public long LatestVersion { get; set; } // 0x28
	}
}
