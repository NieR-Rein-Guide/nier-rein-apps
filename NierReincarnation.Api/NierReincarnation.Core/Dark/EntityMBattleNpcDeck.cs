using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_deck")]
    public class EntityMBattleNpcDeck
    {
        [Key(0)] // RVA: 0x1DD84CC Offset: 0x1DD84CC VA: 0x1DD84CC
        public long BattleNpcId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DD850C Offset: 0x1DD850C VA: 0x1DD850C
        public DeckType DeckType { get; set; } // 0x18

        [Key(2)] // RVA: 0x1DD854C Offset: 0x1DD854C VA: 0x1DD854C
        public int BattleNpcDeckNumber { get; set; } // 0x1C

        [Key(3)] // RVA: 0x1DD858C Offset: 0x1DD858C VA: 0x1DD858C
        public string BattleNpcDeckCharacterUuid01 { get; set; } // 0x20

        [Key(4)] // RVA: 0x1DD85A0 Offset: 0x1DD85A0 VA: 0x1DD85A0
        public string BattleNpcDeckCharacterUuid02 { get; set; } // 0x28

        [Key(5)] // RVA: 0x1DD85B4 Offset: 0x1DD85B4 VA: 0x1DD85B4
        public string BattleNpcDeckCharacterUuid03 { get; set; } // 0x30

        [Key(6)] // RVA: 0x1DD85C8 Offset: 0x1DD85C8 VA: 0x1DD85C8
        public string Name { get; set; } // 0x38

        [Key(7)] // RVA: 0x1DD85DC Offset: 0x1DD85DC VA: 0x1DD85DC
        public int Power { get; set; } // 0x40
    }
}
