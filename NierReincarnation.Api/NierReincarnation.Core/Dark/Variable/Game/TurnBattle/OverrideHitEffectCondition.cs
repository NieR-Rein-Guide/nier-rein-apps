namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class OverrideHitEffectCondition
{
    [Key(0)]
    public object Unk1 { get; set; }

    [Key(1)]
    public OverrideHitEffectConditionType? ConditionType { get; set; }

    [Key(2)]
    public int ConditionIndex { get; set; }

    [Key(3)]
    public int ConditionValue { get; set; }
}
