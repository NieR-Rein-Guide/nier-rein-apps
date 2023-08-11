using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_daily_group")]
    public class EntityMEventQuestDailyGroup
    {
        [Key(0)]
        public int EventQuestDailyGroupId { get; set; }

        [Key(1)]
        public long StartDatetime { get; set; }

        [Key(2)]
        public long EndDatetime { get; set; }

        [Key(3)]
        public int EventQuestDailyGroupTargetChapterId { get; set; }

        [Key(4)]
        public int EventQuestDailyGroupCompleteRewardId { get; set; }

        [Key(5)]
        public int EventQuestDailyGroupMessageId { get; set; }
    }
}
