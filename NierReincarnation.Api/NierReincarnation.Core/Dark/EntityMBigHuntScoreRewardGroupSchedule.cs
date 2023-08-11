using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_big_hunt_score_reward_group_schedule")]
    public class EntityMBigHuntScoreRewardGroupSchedule
    {
        [Key(0)]
        public int BigHuntScoreRewardGroupScheduleId { get; set; }

        [Key(1)]
        public int GroupIndex { get; set; }

        [Key(2)]
        public int BigHuntScoreRewardGroupId { get; set; }

        [Key(3)]
        public long StartDatetime { get; set; }
    }
}
