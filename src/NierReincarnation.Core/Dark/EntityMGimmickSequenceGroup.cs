using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMGimmickSequenceGroup))]
public class EntityMGimmickSequenceGroup
{
    [Key(0)]
    public int GimmickSequenceGroupId { get; set; }

    [Key(1)]
    public int GroupIndex { get; set; }

    [Key(2)]
    public int GimmickSequenceId { get; set; }
}
