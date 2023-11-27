using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMOverrideHitEffectConditionCritical))]
public class EntityMOverrideHitEffectConditionCritical
{
    [Key(0)]
    public int OverrideHitEffectConditionId { get; set; }

    [Key(1)]
    public bool IsCritical { get; set; }
}
