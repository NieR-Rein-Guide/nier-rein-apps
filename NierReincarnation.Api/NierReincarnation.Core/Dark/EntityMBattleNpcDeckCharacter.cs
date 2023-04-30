using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_deck_character")]
    public class EntityMBattleNpcDeckCharacter
    {
        [Key(0)] // RVA: 0x1DD85F0 Offset: 0x1DD85F0 VA: 0x1DD85F0
        public long BattleNpcId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DD8630 Offset: 0x1DD8630 VA: 0x1DD8630
        public string BattleNpcDeckCharacterUuid { get; set; } // 0x18

        [Key(2)] // RVA: 0x1DD8670 Offset: 0x1DD8670 VA: 0x1DD8670
        public string BattleNpcCostumeUuid { get; set; } // 0x20

        [Key(3)] // RVA: 0x1DD8684 Offset: 0x1DD8684 VA: 0x1DD8684
        public string MainBattleNpcWeaponUuid { get; set; } // 0x28

        [Key(4)] // RVA: 0x1DD8698 Offset: 0x1DD8698 VA: 0x1DD8698
        public string BattleNpcCompanionUuid { get; set; } // 0x30

        [Key(5)] // RVA: 0x1DD86AC Offset: 0x1DD86AC VA: 0x1DD86AC
        public int Power { get; set; } // 0x38

        [Key(6)] // RVA: 0x1F72568 Offset: 0x1F72568 VA: 0x1F72568
        public string BattleNpcThoughtUuid { get; set; } // 0x40
    }
}
