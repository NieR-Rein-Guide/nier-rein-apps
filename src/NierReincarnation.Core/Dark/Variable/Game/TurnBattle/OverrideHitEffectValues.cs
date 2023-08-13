namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class OverrideHitEffectValues
{
    [Key(0)]
    public List<OverrideHitEffectValue> List { get; set; } = new List<OverrideHitEffectValue>();
}
