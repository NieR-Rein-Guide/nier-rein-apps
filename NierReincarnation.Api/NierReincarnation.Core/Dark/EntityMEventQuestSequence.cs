using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_event_quest_sequence")]
public class EntityMEventQuestSequence
{
    [Key(0)]
    public int EventQuestSequenceId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int QuestId { get; set; }
}
