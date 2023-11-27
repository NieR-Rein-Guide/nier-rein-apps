using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCageOrnamentMainQuestChapterStill))]
public class EntityMCageOrnamentMainQuestChapterStill
{
    [Key(0)]
    public int MainQuestChapterId { get; set; }

    [Key(1)]
    public int CageOrnamentStillReleaseConditionId { get; set; }
}
