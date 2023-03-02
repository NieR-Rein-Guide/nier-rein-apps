using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_damage_multiply_hit_index_value_group")]
    public class EntityMSkillDamageMultiplyHitIndexValueGroup
    {
        [Key(0)]
        public int SkillDamageMultiplyHitIndexValueGroupId { get; set; } // 0x10
        [Key(1)]
        public int SkillDamageMultiplyHitIndexValueGroupIndex { get; set; } // 0x14
        [Key(2)]
        public int TotalHitCountConditionLower { get; set; } // 0x18
        [Key(3)]
        public int TotalHitCountConditionUpper { get; set; } // 0x1C
        [Key(4)]
        public int HitIndex { get; set; } // 0x20
        [Key(5)]
        public int DamageMultiplyCoefficientValuePermil { get; set; } // 0x24
    }
}