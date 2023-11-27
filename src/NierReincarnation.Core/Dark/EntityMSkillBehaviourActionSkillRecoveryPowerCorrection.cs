using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActionSkillRecoveryPowerCorrection))]
public class EntityMSkillBehaviourActionSkillRecoveryPowerCorrection
{
    [Key(0)]
    public int SkillBehaviourActionId { get; set; }

    [Key(1)]
    public int CorrectionValuePermil { get; set; }
}
