using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_limit_content_deck_restriction")]
    public class EntityMEventQuestLimitContentDeckRestriction
    {
        [Key(0)]
        public int EventQuestLimitContentDeckRestrictionId { get; set; } // 0x10

        [Key(1)]
        public int GroupIndex { get; set; } // 0x14

        [Key(2)]
        public int EventQuestLimitContentDeckRestrictionTargetId { get; set; } // 0x18

        [Key(3)]
        public long StartDatetime { get; set; } // 0x20

        [Key(4)]
        public long EndDatetime { get; set; } // 0x28
    }
}
