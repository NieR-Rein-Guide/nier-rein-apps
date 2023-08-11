using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_damage_multiply_abnormal_attached_value_group")]
    public class EntityMSkillDamageMultiplyAbnormalAttachedValueGroup
    {
        [Key(0)]
        public int SkillDamageMultiplyAbnormalAttachedValueGroupId { get; set; }

        [Key(1)]
        public int SkillDamageMultiplyAbnormalAttachedValueGroupIndex { get; set; }

        [Key(2)]
        public int PolarityConditionType { get; set; }

        [Key(3)]
        public int SkillAbnormalTypeIdCondition { get; set; }

        [Key(4)]
        public int TargetType { get; set; }

        [Key(5)]
        public int DamageMultiplyCoefficientValuePermil { get; set; }
    }
}
