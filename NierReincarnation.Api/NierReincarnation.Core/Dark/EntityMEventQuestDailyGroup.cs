using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_daily_group")]
    public class EntityMEventQuestDailyGroup
    {
        [Key(0)]
        public int EventQuestDailyGroupId { get; set; } // 0x10

        [Key(1)]
        public long StartDatetime { get; set; } // 0x18

        [Key(2)]
        public long EndDatetime { get; set; } // 0x20

        [Key(3)]
        public int EventQuestDailyGroupTargetChapterId { get; set; } // 0x28

        [Key(4)]
        public int EventQuestDailyGroupCompleteRewardId { get; set; } // 0x2C

        [Key(5)]
        public int EventQuestDailyGroupMessageId { get; set; } // 0x30
    }
}
