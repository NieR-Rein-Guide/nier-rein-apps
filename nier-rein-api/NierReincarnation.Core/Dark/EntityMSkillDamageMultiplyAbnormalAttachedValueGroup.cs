using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_damage_multiply_abnormal_attached_value_group")]
    public class EntityMSkillDamageMultiplyAbnormalAttachedValueGroup
    {
        [Key(0)]
        public int SkillDamageMultiplyAbnormalAttachedValueGroupId { get; set; } // 0x10
        [Key(1)]
        public int SkillDamageMultiplyAbnormalAttachedValueGroupIndex { get; set; } // 0x14
        [Key(2)]
        public int PolarityConditionType { get; set; } // 0x18
        [Key(3)]
        public int SkillAbnormalTypeIdCondition { get; set; } // 0x1C
        [Key(4)]
        public int TargetType { get; set; } // 0x20
        [Key(5)]
        public int DamageMultiplyCoefficientValuePermil { get; set; } // 0x24
    }
}