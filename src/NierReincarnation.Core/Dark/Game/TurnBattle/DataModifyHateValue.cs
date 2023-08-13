namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class DataModifyHateValue
{
    [Key(0)]
    public HateValueCalculationType CalculationType { get; set; }

    [Key(1)]
    public int ModifyValue { get; set; }
}
