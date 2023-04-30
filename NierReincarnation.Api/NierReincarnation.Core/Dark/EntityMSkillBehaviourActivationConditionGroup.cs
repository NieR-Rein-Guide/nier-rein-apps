using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_activation_condition_group")]
    public class EntityMSkillBehaviourActivationConditionGroup
    {
        [Key(0)]
        public int SkillBehaviourActivationConditionGroupId { get; set; } // 0x10

        [Key(1)]
        public int ConditionCheckOrder { get; set; } // 0x14

        [Key(2)]
        public SkillBehaviourActivationConditionType SkillBehaviourActivationConditionType { get; set; } // 0x18

        [Key(3)]
        public int SkillBehaviourActivationConditionId { get; set; } // 0x1C
    }
}
