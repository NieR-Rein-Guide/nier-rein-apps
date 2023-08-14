using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_override_hit_effect_condition_critical")]
public class EntityMOverrideHitEffectConditionCritical
{
    [Key(0)]
    public int OverrideHitEffectConditionId { get; set; }

    [Key(1)]
    public bool IsCritical { get; set; }
}