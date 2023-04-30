using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_event_group")]
    public class EntityMBattleEventGroup
    {
        [Key(0)]
        public int BattleEventGroupId { get; set; } // 0x10

        [Key(1)]
        public int BattleEventId { get; set; } // 0x14
    }
}
