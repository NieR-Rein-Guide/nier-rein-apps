using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_limit_content_deck_restriction_target")]
    public class EntityMEventQuestLimitContentDeckRestrictionTarget
    {
        [Key(0)]
        public int EventQuestLimitContentDeckRestrictionTargetId { get; set; }

        [Key(1)]
        public LimitContentDeckRestrictionType LimitContentDeckRestrictionType { get; set; }
    }
}
