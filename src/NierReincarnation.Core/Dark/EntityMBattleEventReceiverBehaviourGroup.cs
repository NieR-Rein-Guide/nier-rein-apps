using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleEventReceiverBehaviourGroup))]
public class EntityMBattleEventReceiverBehaviourGroup
{
    [Key(0)]
    public int BattleEventReceiverBehaviourGroupId { get; set; }

    [Key(1)]
    public int ExecuteOrder { get; set; }

    [Key(2)]
    public int BattleEventReceiverBehaviourType { get; set; }

    [Key(3)]
    public int BattleEventReceiverBehaviourId { get; set; }
}
