namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class AbnormalBehaviourHash
{
    [Key(0)]
    public AbnormalHash AbnormalHash { get; set; }

    [Key(1)]
    public int AbnormalBehaviourIndex { get; set; }
}
