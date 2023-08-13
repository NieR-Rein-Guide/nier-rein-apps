namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class AbnormalLifetime
{
    [Key(0)]
    public AbnormalHash AbnormalHash { get; set; }

    [Key(1)]
    public List<AbnormalLifetimeMethodType> AbnormalLifetimeMethodTypes { get; set; }

    [Key(2)]
    public List<int> CurrentLifetimes { get; set; }

    [Key(3)]
    public List<int> MaxLifetimes { get; set; }

    [Key(4)]
    public AbnormalLifetimeBehaviourConditionType AbnormalLifetimeBehaviourConditionType { get; set; }

    [Key(5)]
    public int AttachedOrder { get; set; }
}
