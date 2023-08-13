namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class SkillHash
{
    [Key(0)]
    public ActorHash ActorHash { get; set; }

    [Key(1)]
    public BattleSkillType BattleSkillType { get; set; }

    [Key(2)]
    public int HashValue { get; set; }
}
