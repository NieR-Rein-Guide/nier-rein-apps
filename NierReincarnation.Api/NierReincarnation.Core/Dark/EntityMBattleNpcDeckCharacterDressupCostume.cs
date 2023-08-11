using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_deck_character_dressup_costume")]
    public class EntityMBattleNpcDeckCharacterDressupCostume
    {
        [Key(0)]
        public long BattleNpcId { get; set; }

        [Key(1)]
        public string BattleNpcDeckCharacterUuid { get; set; }

        [Key(2)]
        public int DressupCostumeId { get; set; }
    }
}
