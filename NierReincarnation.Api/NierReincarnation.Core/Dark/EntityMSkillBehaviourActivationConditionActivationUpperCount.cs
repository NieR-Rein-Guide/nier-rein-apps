using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_activation_condition_activation_upper_count")]
    public class EntityMSkillBehaviourActivationConditionActivationUpperCount
    {
        [Key(0)]
        public int SkillBehaviourActivationConditionId { get; set; } // 0x10

        [Key(1)]
        public int ActivationUpperCount { get; set; } // 0x14
    }
}
