using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_behaviour_action_recovery_point_correction")]
public class EntityMSkillBehaviourActionRecoveryPointCorrection
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public int RecoveryPointCorrectionTargetSkillType { get; set; }

    [Key(2)]
    public int RecoveryPointCorrectionCoefficientValue { get; set; }
}
