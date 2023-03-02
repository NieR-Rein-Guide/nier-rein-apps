using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_event_trigger_behaviour_group")]
    public class EntityMBattleEventTriggerBehaviourGroup
    {
        [Key(0)]
        public int BattleEventTriggerBehaviourGroupId { get; set; } // 0x10
        [Key(1)]
        public int BattleEventTriggerBehaviourType { get; set; } // 0x14
        [Key(2)]
        public int BattleEventTriggerBehaviourId { get; set; } // 0x18
    }
}