namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyDetailCritical
{
    [Key(0)]
    public bool IsCriticalCondition { get; set; }

    [Key(1)]
    public int CoefficientValuePermil { get; set; }

    [Key(2)]
    public DamageMultiplyTargetType MultiplyTargetType { get; set; }
}
