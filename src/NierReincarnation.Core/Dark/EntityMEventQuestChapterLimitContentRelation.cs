using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMEventQuestChapterLimitContentRelation))]
public class EntityMEventQuestChapterLimitContentRelation
{
    [Key(0)]
    public int EventQuestChapterId { get; set; }

    [Key(1)]
    public int EventQuestLimitContentId { get; set; }
}
