using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_deck_limit_content_restricted")]
    public class EntityMBattleNpcDeckLimitContentRestricted
    {
        [Key(0)]
        public long BattleNpcId { get; set; } // 0x10
        [Key(1)]
        public int EventQuestChapterId { get; set; } // 0x18
        [Key(2)]
        public int QuestId { get; set; } // 0x1C
        [Key(3)]
        public string DeckRestrictedUuid { get; set; } // 0x20
        [Key(4)]
        public int PossessionType { get; set; } // 0x28
        [Key(5)]
        public string TargetUuid { get; set; } // 0x30
    }
}