namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class BuffTypeId
{
    [Key(0)]
    public BuffType BuffType { get; set; }

    [Key(1)]
    public StatusKindType StatusType { get; set; }
}
