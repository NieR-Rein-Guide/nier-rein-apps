using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_event_receiver_behaviour_group")]
    public class EntityMBattleEventReceiverBehaviourGroup
    {
        [Key(0)]
        public int BattleEventReceiverBehaviourGroupId { get; set; } // 0x10

        [Key(1)]
        public int ExecuteOrder { get; set; } // 0x14

        [Key(2)]
        public int BattleEventReceiverBehaviourType { get; set; } // 0x18

        [Key(3)]
        public int BattleEventReceiverBehaviourId { get; set; } // 0x1C
    }
}
