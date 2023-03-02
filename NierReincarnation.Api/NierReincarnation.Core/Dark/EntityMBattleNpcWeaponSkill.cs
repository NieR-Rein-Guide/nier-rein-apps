using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_weapon_skill")]
    public class EntityMBattleNpcWeaponSkill
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10
        [Key(1)]
        public string BattleNpcWeaponUuid { get; set; } // 0x18
        [Key(2)]
        public int SlotNumber { get; set; } // 0x20
        [Key(3)]
        public int Level { get; set; } // 0x24
    }
}