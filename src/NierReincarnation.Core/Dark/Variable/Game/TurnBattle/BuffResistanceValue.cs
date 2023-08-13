namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class BuffResistanceValue
{
    [Key(0)]
    public BuffResistanceType BuffType { get; set; }

    [Key(1)]
    public BuffResistanceStatusKindType StatusKindType { get; set; }

    [Key(2)]
    public int BlockProbabilityPermil { get; set; }
}
