using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_battle_event")]
public class EntityMBattleEvent
{
    [Key(0)]
    public int BattleEventId { get; set; }

    [Key(1)]
    public int BattleEventTriggerBehaviourGroupId { get; set; }

    [Key(2)]
    public int BattleEventReceiverBehaviourGroupId { get; set; }
}
