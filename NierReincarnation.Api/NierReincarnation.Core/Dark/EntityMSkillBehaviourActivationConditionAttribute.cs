using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_activation_condition_attribute")]
    public class EntityMSkillBehaviourActivationConditionAttribute
    {
        [Key(0)]
        public int SkillBehaviourActivationConditionId { get; set; } // 0x10

        [Key(1)]
        public int SkillBehaviourActivationConditionAttributeType { get; set; } // 0x14
    }
}
