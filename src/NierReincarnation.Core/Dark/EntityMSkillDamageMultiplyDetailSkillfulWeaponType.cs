using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_skill_damage_multiply_detail_skillful_weapon_type")]
public class EntityMSkillDamageMultiplyDetailSkillfulWeaponType
{
    [Key(0)]
    public int SkillDamageMultiplyDetailId { get; set; }

    [Key(1)]
    public DamageMultiplySkillfulWeaponConditionTargetType ConditionTargetType { get; set; }

    [Key(2)]
    public WeaponType WeaponType { get; set; }

    [Key(3)]
    public bool IsSkillfulMainWeapon { get; set; }

    [Key(4)]
    public int DamageMultiplyCoefficientValuePermil { get; set; }
}
