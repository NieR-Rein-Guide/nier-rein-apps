namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyDetailAlways
{
    [Key(0)]
    public DamageMultiplyTargetType MultiplyTargetType { get; set; }

    [Key(1)]
    public int CoefficientValuePermil { get; set; }
}
