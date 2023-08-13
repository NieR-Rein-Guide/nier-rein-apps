namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class TurnBattleSnapshot
{
    [Key(0)]
    public int TurnBattleSnapshotVersion { get; set; }

    [Key(1)]
    public TurnBattleBattleSnapshot BattleSnapshot { get; set; }

    [Key(2)]
    public List<TurnBattleActorSnapshot> ActorSnapshots { get; set; } = new List<TurnBattleActorSnapshot>();

    [Key(3)]
    public List<TurnBattleSkillSnapshot> SkillSnapshots { get; set; } = new List<TurnBattleSkillSnapshot>();

    [Key(4)]
    public List<TurnBattleSkillBehaviourSnapshot> SkillBehaviourSnapshots { get; set; } = new List<TurnBattleSkillBehaviourSnapshot>();
}
