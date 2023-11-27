using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMMainQuestSequence))]
public class EntityMMainQuestSequence
{
    [Key(0)]
    public int MainQuestSequenceId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int QuestId { get; set; }
}
