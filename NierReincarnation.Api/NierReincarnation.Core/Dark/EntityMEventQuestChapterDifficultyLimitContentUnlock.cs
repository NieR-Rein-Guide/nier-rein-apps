using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_chapter_difficulty_limit_content_unlock")]
    public class EntityMEventQuestChapterDifficultyLimitContentUnlock
    {
        [Key(0)]
        public int EventQuestChapterId { get; set; }

        [Key(1)]
        public DifficultyType DifficultyType { get; set; }

        [Key(2)]
        public int UnlockEvaluateConditionId { get; set; }
    }
}
