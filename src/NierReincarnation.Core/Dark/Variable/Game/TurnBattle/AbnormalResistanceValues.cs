namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class AbnormalResistanceValues
{
    [Key(0)]
    public List<AbnormalResistanceValue> List { get; set; } = new List<AbnormalResistanceValue>();
}
