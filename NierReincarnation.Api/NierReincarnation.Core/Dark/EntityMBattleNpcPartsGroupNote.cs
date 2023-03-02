using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_parts_group_note")]
    public class EntityMBattleNpcPartsGroupNote
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10
        [Key(1)]
        public int PartsGroupId { get; set; } // 0x18
        [Key(2)]
        public long FirstAcquisitionDatetime { get; set; } // 0x20
    }
}