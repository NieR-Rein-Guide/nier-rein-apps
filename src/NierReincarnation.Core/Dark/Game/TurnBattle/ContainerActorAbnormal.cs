namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class ContainerActorAbnormal
{
    [Key(0)]
    public List<AbnormalLifetime> ActiveAbnormalLifetimeList { get; set; } = new List<AbnormalLifetime>();

    [Key(1)]
    public List<AbnormalBehaviourHash> ActivatedAbnormalBehaviourHashList { get; set; } = new List<AbnormalBehaviourHash>();
}
