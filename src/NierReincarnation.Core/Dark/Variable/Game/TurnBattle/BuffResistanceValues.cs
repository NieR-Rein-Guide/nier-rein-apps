namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class BuffResistanceValues
{
    [Key(0)]
    public List<BuffResistanceValue> List { get; set; } = new List<BuffResistanceValue>();
}
