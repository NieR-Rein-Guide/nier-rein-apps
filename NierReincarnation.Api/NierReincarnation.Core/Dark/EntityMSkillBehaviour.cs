using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_behaviour")]
    public class EntityMSkillBehaviour
    {
        [Key(0)] // RVA: 0x1DE417C Offset: 0x1DE417C VA: 0x1DE417C
        public int SkillBehaviourId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DE41BC Offset: 0x1DE41BC VA: 0x1DE41BC
        public SkillBehaviourType SkillBehaviourType { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DE41D0 Offset: 0x1DE41D0 VA: 0x1DE41D0
        public int SkillBehaviourActionId { get; set; } // 0x18
        [Key(3)] // RVA: 0x1DE41E4 Offset: 0x1DE41E4 VA: 0x1DE41E4
        public int SkillBehaviourActivationMethodId { get; set; } // 0x1C
        [Key(4)] // RVA: 0x1DE41F8 Offset: 0x1DE41F8 VA: 0x1DE41F8
        public int SkillBehaviourAssetCalculatorId { get; set; } // 0x20
        [Key(5)] // RVA: 0x1DE420C Offset: 0x1DE420C VA: 0x1DE420C
        public int HitRatioPermil { get; set; } // 0x24
        [Key(6)] // RVA: 0x1DE4220 Offset: 0x1DE4220 VA: 0x1DE4220
        public SkillBehaviourLifetimeCalculationMethodType SkillBehaviourLifetimeCalculationMethodType { get; set; } // 0x28
        [Key(7)] // RVA: 0x1DE4234 Offset: 0x1DE4234 VA: 0x1DE4234
        public int LifetimeCount { get; set; } // 0x2C
        [Key(8)] // RVA: 0x1DE4248 Offset: 0x1DE4248 VA: 0x1DE4248
        public int SkillTargetScopeAssetCalculatorId { get; set; } // 0x30
	}
}
