using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_event")]
    public class EntityMBattleEvent
    {
        [Key(0)]
        public int BattleEventId { get; set; } // 0x10
        [Key(1)]
        public int BattleEventTriggerBehaviourGroupId { get; set; } // 0x14
        [Key(2)]
        public int BattleEventReceiverBehaviourGroupId { get; set; } // 0x18
    }
}