using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_main_quest_sequence_group")]
public class EntityMMainQuestSequenceGroup
{
    [Key(0)]
    public int MainQuestSequenceGroupId { get; set; }

    [Key(1)]
    public DifficultyType DifficultyType { get; set; }

    [Key(2)]
    public int MainQuestSequenceId { get; set; }
}
