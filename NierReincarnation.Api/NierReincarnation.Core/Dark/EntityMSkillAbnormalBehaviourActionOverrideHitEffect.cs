using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_behaviour_action_override_hit_effect")]
    public class EntityMSkillAbnormalBehaviourActionOverrideHitEffect
    {
        [Key(0)]
        public int SkillAbnormalBehaviourActionId { get; set; } // 0x10

        [Key(1)]
        public int OverrideEffectId { get; set; } // 0x14

        [Key(2)]
        public int OverrideSeId { get; set; } // 0x18

        [Key(3)]
        public int Priority { get; set; } // 0x1C

        [Key(4)]
        public bool DisablePlayHitVoice { get; set; } // 0x20

        [Key(5)]
        public bool PlayOnMiss { get; set; } // 0x21

        [Key(6)]
        public bool ForceRotateOnHit { get; set; } // 0x22

        [Key(7)]
        public int OverrideHitEffectConditionGroupId { get; set; } // 0x24

        [Key(8)]
        public int OverrideHitEffectConditionOperationType { get; set; } // 0x28
    }
}
