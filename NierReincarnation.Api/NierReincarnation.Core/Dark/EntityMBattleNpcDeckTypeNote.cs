using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_deck_type_note")]
    public class EntityMBattleNpcDeckTypeNote
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10
        [Key(1)]
        public DeckType DeckType { get; set; } // 0x18
        [Key(2)]
        public int MaxDeckPower { get; set; } // 0x1C
    }
}