using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActionRecoveryPointCorrection))]
public class EntityMSkillBehaviourActionRecoveryPointCorrection
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public RecoveryPointCorrectionTargetSkillType RecoveryPointCorrectionTargetSkillType { get; set; }

    [Key(2)]
    public int RecoveryPointCorrectionCoefficientValue { get; set; }
}
