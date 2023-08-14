using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_abnormal_behaviour_action_override_hit_effect")]
public class EntityMSkillAbnormalBehaviourActionOverrideHitEffect
{
    [Key(0)]
    public int SkillAbnormalBehaviourActionId { get; set; }

    [Key(1)]
    public int OverrideEffectId { get; set; }

    [Key(2)]
    public int OverrideSeId { get; set; }

    [Key(3)]
    public int Priority { get; set; }

    [Key(4)]
    public bool DisablePlayHitVoice { get; set; }

    [Key(5)]
    public bool PlayOnMiss { get; set; }

    [Key(6)]
    public bool ForceRotateOnHit { get; set; }

    [Key(7)]
    public int OverrideHitEffectConditionGroupId { get; set; }

    [Key(8)]
    public int OverrideHitEffectConditionOperationType { get; set; }
}
