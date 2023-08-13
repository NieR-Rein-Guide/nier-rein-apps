namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class TurnBattleSkillBehaviourSnapshot
{
    [Key(0)]
    public ProgressDataKey ProgressDataKey { get; set; }

    [Key(1)]
    public SkillBehaviourHash SkillBehaviourHash { get; set; }

    [Key(2)]
    public int Lifetime { get; set; }

    [Key(3)]
    public bool EndOfLife { get; set; }

    [Key(4)]
    public int ActivatedCount { get; set; }
}
