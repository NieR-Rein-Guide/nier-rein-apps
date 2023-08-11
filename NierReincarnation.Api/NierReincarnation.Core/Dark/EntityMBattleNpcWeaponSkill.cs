using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_weapon_skill")]
    public class EntityMBattleNpcWeaponSkill
    {
        [Key(0)]
        public long BattleNpcId { get; set; }

        [Key(1)]
        public string BattleNpcWeaponUuid { get; set; }

        [Key(2)]
        public int SlotNumber { get; set; }

        [Key(3)]
        public int Level { get; set; }
    }
}
