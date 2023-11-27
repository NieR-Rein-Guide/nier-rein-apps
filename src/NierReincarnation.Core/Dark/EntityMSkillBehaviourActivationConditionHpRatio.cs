using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMSkillBehaviourActivationConditionHpRatio))]
public class EntityMSkillBehaviourActivationConditionHpRatio
{
    [Key(0)]
    public int SkillBehaviourActivationConditionId { get; set; }

    [Key(1)]
    public SkillBehaviourActivationConditionHpRatioThresholdType SkillBehaviourActivationConditionHpRatioThresholdType { get; set; }

    [Key(2)]
    public int ThresholdRatioPermil { get; set; }
}
