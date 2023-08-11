using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_big_hunt_weekly_attribute_score_reward_group_schedule")]
    public class EntityMBigHuntWeeklyAttributeScoreRewardGroupSchedule
    {
        [Key(0)]
        public int BigHuntWeeklyAttributeScoreRewardGroupScheduleId { get; set; }

        [Key(1)]
        public int AttributeType { get; set; }

        [Key(2)]
        public int GroupIndex { get; set; }

        [Key(3)]
        public int BigHuntScoreRewardGroupId { get; set; }

        [Key(4)]
        public long StartDatetime { get; set; }
    }
}
