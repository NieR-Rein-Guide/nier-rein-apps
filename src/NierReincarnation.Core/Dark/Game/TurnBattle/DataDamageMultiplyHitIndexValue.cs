namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class DataDamageMultiplyHitIndexValue
{
    [Key(0)]
    public int TotalHitCountConditionLower { get; set; }

    [Key(1)]
    public int TotalHitCountConditionUpper { get; set; }

    [Key(2)]
    public int HitIndex { get; set; }

    [Key(3)]
    public int CoefficientValuePermil { get; set; }

    [Key(4)]
    public DamageMultiplyTargetType MultiplyTargetType { get; set; }
}
