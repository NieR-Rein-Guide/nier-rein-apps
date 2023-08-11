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
        public int SkillCasttimeBehaviourActionId { get; set; }

        [Key(1)]
        public int SkillCasttimeUpdateValue { get; set; }

        [Key(2)]
        public SkillCasttimeAdvanceType SkillCasttimeAdvanceType { get; set; }

        [Key(3)]
        public int DamageCompareType { get; set; }

        [Key(4)]
        public int DamageConditionValue { get; set; }
    }
}
