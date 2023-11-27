using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleEventReceiverBehaviourHudActSequence))]
public class EntityMBattleEventReceiverBehaviourHudActSequence
{
    [Key(0)]
    public int BattleEventReceiverBehaviourId { get; set; }

    [Key(1)]
    public int HudActSequenceId { get; set; }
}
