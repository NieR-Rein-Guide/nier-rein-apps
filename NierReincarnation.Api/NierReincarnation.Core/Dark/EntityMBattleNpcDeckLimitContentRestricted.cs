using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_battle_npc_deck_limit_content_restricted")]
    public class EntityMBattleNpcDeckLimitContentRestricted
    {
        [Key(0)]
        public long BattleNpcId { get; set; }

        [Key(1)]
        public int EventQuestChapterId { get; set; }

        [Key(2)]
        public int QuestId { get; set; }

        [Key(3)]
        public string DeckRestrictedUuid { get; set; }

        [Key(4)]
        public PossessionType PossessionType { get; set; }

        [Key(5)]
        public string TargetUuid { get; set; }
    }
}
