namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyDetailSkillfulWeaponType
{
    [Key(0)]
    public DamageMultiplySkillfulWeaponConditionTargetType ConditionTargetType { get; set; }

    [Key(1)]
    public WeaponType WeaponType { get; set; }

    [Key(2)]
    public bool IsSkillfulMainWeapon { get; set; }

    [Key(3)]
    public int DamageMultiplyCoefficientValuePermil { get; set; }

    [Key(4)]
    public DamageMultiplyTargetType MultiplyTargetType { get; set; }
}
