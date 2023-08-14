using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_event_quest_sequence_group")]
public class EntityMEventQuestSequenceGroup
{
    // Properties
    [Key(0)]
    public int EventQuestSequenceGroupId { get; set; }

    [Key(1)]
    public DifficultyType DifficultyType { get; set; }

    [Key(2)]
    public int EventQuestSequenceId { get; set; }
}
