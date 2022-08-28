using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_weapon_note")]
    public class EntityMBattleNpcWeaponNote
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10
        [Key(1)]
        public int WeaponId { get; set; } // 0x18
        [Key(2)]
        public int MaxLevel { get; set; } // 0x1C
        [Key(3)]
        public int MaxLimitBreakCount { get; set; } // 0x20
        [Key(4)]
        public long FirstAcquisitionDatetime { get; set; } // 0x28
    }
}