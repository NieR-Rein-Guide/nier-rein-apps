namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyAbnormalAttachedValue
{
    [Key(0)]
    public DamageMultiplyAbnormalAttachedPolarityConditionType PolarityConditionType { get; set; }

    [Key(1)]
    public int AbnormalTypeIdCondition { get; set; }

    [Key(2)]
    public DamageMultiplyAbnormalAttachedTargetType ReferenceActorType { get; set; }

    [Key(3)]
    public int CoefficientValuePermil { get; set; }

    [Key(4)]
    public DamageMultiplyTargetType MultiplyTargetType { get; set; }
}
