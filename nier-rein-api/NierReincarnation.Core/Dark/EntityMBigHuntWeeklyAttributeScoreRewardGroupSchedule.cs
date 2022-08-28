using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_big_hunt_weekly_attribute_score_reward_group_schedule")]
    public class EntityMBigHuntWeeklyAttributeScoreRewardGroupSchedule
    {
        [Key(0)]
        public int BigHuntWeeklyAttributeScoreRewardGroupScheduleId { get; set; } // 0x10
        [Key(1)]
        public int AttributeType { get; set; } // 0x14
        [Key(2)]
        public int GroupIndex { get; set; } // 0x18
        [Key(3)]
        public int BigHuntScoreRewardGroupId { get; set; } // 0x1C
        [Key(4)]
        public long StartDatetime { get; set; } // 0x20
    }
}