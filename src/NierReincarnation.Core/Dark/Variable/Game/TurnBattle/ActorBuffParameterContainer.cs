namespace NierReincarnation.Core.Dark.Variable.Game.TurnBattle;

[MessagePackObject]
public class ActorBuffParameterContainer
{
    [Key(0)]
    public List<ActorBuffParameter> BuffParameterList { get; set; } = new List<ActorBuffParameter>();

    [Key(1)]
    public List<ActorBuffParameter> DebuffParameterList { get; set; } = new List<ActorBuffParameter>();
}
