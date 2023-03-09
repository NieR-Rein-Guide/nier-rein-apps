using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_casttime_behaviour_action_on_skill_damage_condition")]
    public class EntityMSkillCasttimeBehaviourActionOnSkillDamageCondition
    {
        [Key(0)]
        public int SkillCasttimeBehaviourActionId { get; set; } // 0x10
        [Key(1)]
        public int SkillCasttimeUpdateValue { get; set; } // 0x14
        [Key(2)]
        public SkillCasttimeAdvanceType SkillCasttimeAdvanceType { get; set; } // 0x18
        [Key(3)]
        public int DamageCompareType { get; set; } // 0x1C
        [Key(4)]
        public int DamageConditionValue { get; set; } // 0x20
    }
}