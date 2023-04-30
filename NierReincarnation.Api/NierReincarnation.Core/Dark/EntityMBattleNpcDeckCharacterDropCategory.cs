using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_deck_character_drop_category")]
    public class EntityMBattleNpcDeckCharacterDropCategory
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10

        [Key(1)]
        public string BattleNpcDeckCharacterUuid { get; set; } // 0x18

        [Key(2)]
        public int BattleDropCategoryId { get; set; } // 0x20
    }
}
