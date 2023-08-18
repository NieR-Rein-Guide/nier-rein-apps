using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_abnormal_behaviour_action_override_evasion_value")]
public class EntityMSkillAbnormalBehaviourActionOverrideEvasionValue
{
    [Key(0)]
    public int SkillAbnormalBehaviourActionId { get; set; }

    [Key(1)]
    public int CorrectionValuePermil { get; set; }
}
