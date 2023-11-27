using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMEvaluateConditionValueGroup))]
public class EntityMEvaluateConditionValueGroup
{
    [Key(0)]
    public int EvaluateConditionValueGroupId { get; set; }

    [Key(1)]
    public int GroupIndex { get; set; }

    [Key(2)]
    public long Value { get; set; }
}
