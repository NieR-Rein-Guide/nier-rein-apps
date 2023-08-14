using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_event_quest_chapter_limit_content_relation")]
public class EntityMEventQuestChapterLimitContentRelation
{
    [Key(0)]
    public int EventQuestChapterId { get; set; }

    [Key(1)]
    public int EventQuestLimitContentId { get; set; }
}