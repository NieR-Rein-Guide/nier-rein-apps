using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMOverrideHitEffectConditionGroup))]
public class EntityMOverrideHitEffectConditionGroup
{
    [Key(0)]
    public int OverrideHitEffectConditionGroupId { get; set; }

    [Key(1)]
    public int ConditionIndex { get; set; }

    [Key(2)]
    public int ConditionType { get; set; }

    [Key(3)]
    public int OverrideHitEffectConditionId { get; set; }
}
