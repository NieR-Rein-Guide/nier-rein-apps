using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_event_trigger_behaviour_battle_start")]
    public class EntityMBattleEventTriggerBehaviourBattleStart
    {
        [Key(0)]
        public int BattleEventTriggerBehaviourId { get; set; } // 0x10
        [Key(1)]
        public bool TriggerOnBattleRestore { get; set; } // 0x14
    }
}