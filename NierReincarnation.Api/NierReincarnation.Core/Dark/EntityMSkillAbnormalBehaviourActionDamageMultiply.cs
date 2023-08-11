using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_abnormal_behaviour_action_damage_multiply")]
    public class EntityMSkillAbnormalBehaviourActionDamageMultiply
    {
        [Key(0)]
        public int SkillAbnormalBehaviourActionId { get; set; }

        [Key(1)]
        public int DamageMultiplyDetailType { get; set; }

        [Key(2)]
        public DamageMultiplyTargetType DamageMultiplyTargetType { get; set; }

        [Key(3)]
        public int DamageMultiplyAbnormalDetailId { get; set; }
    }
}
