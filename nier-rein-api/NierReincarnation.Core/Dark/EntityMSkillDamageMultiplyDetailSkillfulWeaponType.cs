using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_skill_damage_multiply_detail_skillful_weapon_type")]
    public class EntityMSkillDamageMultiplyDetailSkillfulWeaponType
    {
        [Key(0)]
        public int SkillDamageMultiplyDetailId { get; set; } // 0x10
        [Key(1)]
        public int ConditionTargetType { get; set; } // 0x14
        [Key(2)]
        public int WeaponType { get; set; } // 0x18
        [Key(3)]
        public bool IsSkillfulMainWeapon { get; set; } // 0x1C
        [Key(4)]
        public int DamageMultiplyCoefficientValuePermil { get; set; } // 0x20
    }
}