namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class AttributeDamageCorrectionValue
{
    [Key(0)]
    public AttributeType AttributeType { get; set; }

    [Key(1)]
    public int CorrectionValue { get; set; }

    [Key(2)]
    public DamageCorrectionOverlapType OverlapType { get; set; }

    [Key(3)]
    public bool IsExcepting { get; set; }
}
