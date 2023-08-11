using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_deck_character_type")]
    public class EntityMBattleNpcDeckCharacterType
    {
        [Key(0)]
        public long BattleNpcId { get; set; }

        [Key(1)]
        public string BattleNpcDeckCharacterUuid { get; set; }

        [Key(2)]
        public BattleEnemyType BattleEnemyType { get; set; }
    }
}
