using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_event_quest_daily_group_complete_reward")]
    public class EntityMEventQuestDailyGroupCompleteReward
    {
        [Key(0)]
        public int EventQuestDailyGroupCompleteRewardId { get; set; } // 0x10
        [Key(1)]
        public int SortOrder { get; set; } // 0x14
        [Key(2)]
        public int PossessionType { get; set; } // 0x18
        [Key(3)]
        public int PossessionId { get; set; } // 0x1C
        [Key(4)]
        public int Count { get; set; } // 0x20
    }
}