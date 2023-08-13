using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_behaviour_action_skill_recovery_power_correction")]
public class EntityMSkillBehaviourActionSkillRecoveryPowerCorrection
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public int CorrectionValuePermil { get; set; }
}
