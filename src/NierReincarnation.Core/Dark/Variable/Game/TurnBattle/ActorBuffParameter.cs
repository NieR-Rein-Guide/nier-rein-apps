namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class ActorBuffParameter
{
    [Key(0)]
    public BuffTypeId BuffTypeId { get; set; }

    [Key(1)]
    public int Lifetime { get; set; }

    [Key(2)]
    public int CurrentPower { get; set; }
}
