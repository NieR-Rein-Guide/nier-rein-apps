using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMEventQuestChapterDifficultyLimitContentUnlock))]
public class EntityMEventQuestChapterDifficultyLimitContentUnlock
{
    [Key(0)]
    public int EventQuestChapterId { get; set; }

    [Key(1)]
    public DifficultyType DifficultyType { get; set; }

    [Key(2)]
    public int UnlockEvaluateConditionId { get; set; }
}
