using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_big_hunt_score_reward_group")]
    public class EntityMBigHuntScoreRewardGroup
    {
        [Key(0)]
        public int BigHuntScoreRewardGroupId { get; set; } // 0x10
        [Key(1)]
        public long NecessaryScore { get; set; } // 0x18
        [Key(2)]
        public int BigHuntRewardGroupId { get; set; } // 0x20
    }
}