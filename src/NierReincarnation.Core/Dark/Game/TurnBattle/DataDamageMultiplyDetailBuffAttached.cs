namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyDetailBuffAttached
{
    [Key(0)]
    public DamageMultiplyTargetType MultiplyTargetType { get; set; }

    [Key(1)]
    public DamageMultiplyBuffAttachedConditionTargetType ConditionTargetType { get; set; }

    [Key(2)]
    public DamageMultiplyBuffAttachedTargetBuffType TargetBuffType { get; set; }

    [Key(3)]
    public DamageMultiplyBuffAttachedTargetStatusKindType TargetStatusKindType { get; set; }

    [Key(4)]
    public int DamageMultiplyCoefficientValuePermil { get; set; }
}
