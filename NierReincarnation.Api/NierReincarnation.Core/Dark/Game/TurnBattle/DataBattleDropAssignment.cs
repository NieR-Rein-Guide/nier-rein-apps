namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class DataBattleDropAssignment
{
    [Key(0)]
    public ActorHash ActorHash { get; set; }

    [Key(1)]
    public List<int> DropEffectIds { get; set; } = new List<int>();
}
