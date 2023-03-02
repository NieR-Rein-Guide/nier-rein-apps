using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_parts")]
    public class EntityMBattleNpcParts
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10
        [Key(1)]
        public string BattleNpcPartsUuid { get; set; } // 0x18
        [Key(2)]
        public int PartsId { get; set; } // 0x20
        [Key(3)]
        public int Level { get; set; } // 0x24
        [Key(4)]
        public int PartsStatusMainId { get; set; } // 0x28
        [Key(5)]
        public bool IsProtected { get; set; } // 0x2C
        [Key(6)]
        public long AcquisitionDatetime { get; set; } // 0x30
    }
}