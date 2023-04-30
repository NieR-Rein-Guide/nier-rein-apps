using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_quest_limit_content_status")]
    public class EntityIUserQuestLimitContentStatus
    {
        [Key(0)]
        public long UserId { get; set; } // 0x10

        [Key(1)]
        public int QuestId { get; set; } // 0x18

        [Key(2)]
        public int LimitContentQuestStatusType { get; set; } // 0x1C

        [Key(3)]
        public int EventQuestChapterId { get; set; } // 0x20

        [Key(4)]
        public long LatestVersion { get; set; } // 0x28
    }
}
