using System.Collections.Generic;
using MessagePack;

namespace NierReincarnation.Core.Dark.Game.TurnBattle;

[MessagePackObject]
public class ContainerActorAbnormal
{
    [Key(0)] // RVA: 0x1DEC048 Offset: 0x1DEC048 VA: 0x1DEC048
    public List<AbnormalLifetime> ActiveAbnormalLifetimeList { get; set; } = new List<AbnormalLifetime>();
    [Key(1)] // RVA: 0x1DEC05C Offset: 0x1DEC05C VA: 0x1DEC05C
    public List<AbnormalBehaviourHash> ActivatedAbnormalBehaviourHashList { get; set; } = new List<AbnormalBehaviourHash>();
}
