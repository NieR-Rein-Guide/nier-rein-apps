namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class AttributeDamageCorrectionValues
{
    [Key(0)]
    public List<AttributeDamageCorrectionValue> List { get; set; } = new List<AttributeDamageCorrectionValue>();
}
