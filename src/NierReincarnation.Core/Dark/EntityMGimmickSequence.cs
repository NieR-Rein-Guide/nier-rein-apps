using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_gimmick_sequence")]
public class EntityMGimmickSequence
{
    [Key(0)]
    public int GimmickSequenceId { get; set; }

    [Key(1)]
    public int GimmickSequenceClearConditionType { get; set; }

    [Key(2)]
    public int NextGimmickSequenceGroupId { get; set; }

    [Key(3)]
    public int GimmickGroupId { get; set; }

    [Key(4)]
    public int GimmickSequenceRewardGroupId { get; set; }

    [Key(5)]
    public FlowType FlowType { get; set; }

    [Key(6)]
    public int ProgressRequireHour { get; set; }

    [Key(7)]
    public long ProgressStartDatetime { get; set; }
}
