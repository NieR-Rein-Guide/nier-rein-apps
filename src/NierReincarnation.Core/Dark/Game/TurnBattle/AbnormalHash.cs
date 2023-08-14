namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class AbnormalHash
{
    [Key(0)]
    public SkillBehaviourHash SkillBehaviourHash { get; set; }

    [Key(1)]
    public int HashValue { get; set; }
}
