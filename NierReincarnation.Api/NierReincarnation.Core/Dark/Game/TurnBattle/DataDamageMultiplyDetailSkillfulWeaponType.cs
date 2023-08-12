using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyDetailSkillfulWeaponType
{
    [Key(0)] // RVA: 0x1DEC1E0 Offset: 0x1DEC1E0 VA: 0x1DEC1E0
    public DamageMultiplySkillfulWeaponConditionTargetType ConditionTargetType { get; set; }

    [Key(1)] // RVA: 0x1DEC1F4 Offset: 0x1DEC1F4 VA: 0x1DEC1F4
    public WeaponType WeaponType { get; set; }

    [Key(2)] // RVA: 0x1DEC208 Offset: 0x1DEC208 VA: 0x1DEC208
    public bool IsSkillfulMainWeapon { get; set; }

    [Key(3)] // RVA: 0x1DEC21C Offset: 0x1DEC21C VA: 0x1DEC21C
    public int DamageMultiplyCoefficientValuePermil { get; set; }

    [Key(4)] // RVA: 0x1DEC230 Offset: 0x1DEC230 VA: 0x1DEC230
    public DamageMultiplyTargetType MultiplyTargetType { get; set; }
}
