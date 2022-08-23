using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour_activation_method")]
    public class EntityMSkillBehaviourActivationMethod
    {
        [Key(0)] // RVA: 0x1DE4D3C Offset: 0x1DE4D3C VA: 0x1DE4D3C
        public int SkillBehaviourActivationMethodId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DE4D7C Offset: 0x1DE4D7C VA: 0x1DE4D7C
        public ActivationMethodType ActivationMethodType { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DE4D90 Offset: 0x1DE4D90 VA: 0x1DE4D90
        public int SkillBehaviourActivationConditionGroupId { get; set; } // 0x18
	}
}
