using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_activation_condition_in_skill_flow")]
    public class EntityMSkillBehaviourActivationConditionInSkillFlow
    {
        [Key(0)]
        public int SkillBehaviourActivationConditionId { get; set; } // 0x10

        [Key(1)]
        public int RunningSkillBehaviourType { get; set; } // 0x14
    }
}
