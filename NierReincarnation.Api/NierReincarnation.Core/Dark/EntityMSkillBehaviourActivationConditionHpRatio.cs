using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_activation_condition_hp_ratio")]
    public class EntityMSkillBehaviourActivationConditionHpRatio
    {
        [Key(0)]
        public int SkillBehaviourActivationConditionId { get; set; }

        [Key(1)]
        public SkillBehaviourActivationConditionHpRatioThresholdType SkillBehaviourActivationConditionHpRatioThresholdType { get; set; }

        [Key(2)]
        public int ThresholdRatioPermil { get; set; }
    }
}
