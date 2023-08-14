namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class SkillBehaviourHash
{
    [Key(0)]
    public SkillHash SkillHash { get; set; }

    [Key(1)]
    public int SkillBehaviourOrder { get; set; }

    [Key(2)]
    public int HashValue { get; set; }
}
