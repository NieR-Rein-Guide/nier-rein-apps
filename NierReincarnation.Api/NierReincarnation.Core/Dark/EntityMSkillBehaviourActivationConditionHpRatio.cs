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
        public int SkillBehaviourActivationConditionId { get; set; } // 0x10

        [Key(1)]
        public SkillBehaviourActivationConditionHpRatioThresholdType SkillBehaviourActivationConditionHpRatioThresholdType { get; set; } // 0x14

        [Key(2)]
        public int ThresholdRatioPermil { get; set; } // 0x18
    }
}
