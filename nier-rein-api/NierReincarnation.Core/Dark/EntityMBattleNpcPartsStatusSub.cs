using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_parts_status_sub")]
    public class EntityMBattleNpcPartsStatusSub
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10
        [Key(1)]
        public string BattleNpcPartsUuid { get; set; } // 0x18
        [Key(2)]
        public int StatusIndex { get; set; } // 0x20
        [Key(3)]
        public int PartsStatusSubLotteryId { get; set; } // 0x24
        [Key(4)]
        public int Level { get; set; } // 0x28
        [Key(5)]
        public StatusKindType StatusKindType { get; set; } // 0x2C
        [Key(6)]
        public StatusCalculationType StatusCalculationType { get; set; } // 0x30
        [Key(7)]
        public int StatusChangeValue { get; set; } // 0x34
    }
}