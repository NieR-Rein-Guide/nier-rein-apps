using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMTipDisplayConditionGroup))]
public class EntityMTipDisplayConditionGroup
{
    [Key(0)]
    public int TipDisplayConditionGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public TipDisplayConditionType TipDisplayConditionType { get; set; }

    [Key(3)]
    public int ConditionValue { get; set; }

    [Key(4)]
    public ConditionOperationType ConditionOperationType { get; set; }
}
