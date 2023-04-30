using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_deck_parts_group")]
    public class EntityMBattleNpcDeckPartsGroup
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10

        [Key(1)]
        public string BattleNpcDeckCharacterUuid { get; set; } // 0x18

        [Key(2)]
        public string BattleNpcPartsUuid { get; set; } // 0x20

        [Key(3)]
        public int SortOrder { get; set; } // 0x28
    }
}
