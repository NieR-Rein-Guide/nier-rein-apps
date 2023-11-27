using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMEventQuestDailyGroupTargetChapter))]
public class EntityMEventQuestDailyGroupTargetChapter
{
    [Key(0)]
    public int EventQuestDailyGroupTargetChapterId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int EventQuestChapterId { get; set; }
}
