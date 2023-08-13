using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_event_quest_daily_group_target_chapter")]
public class EntityMEventQuestDailyGroupTargetChapter
{
    [Key(0)]
    public int EventQuestDailyGroupTargetChapterId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int EventQuestChapterId { get; set; }
}
