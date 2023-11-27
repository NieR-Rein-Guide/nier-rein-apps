using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMEventQuestSequence))]
public class EntityMEventQuestSequence
{
    [Key(0)]
    public int EventQuestSequenceId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int QuestId { get; set; }
}
