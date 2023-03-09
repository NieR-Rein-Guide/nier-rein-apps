using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_pvp_weekly_rank_reward_rank_group")]
    public class EntityMPvpWeeklyRankRewardRankGroup
    {
        [Key(0)]
        public int PvpWeeklyRankRewardRankGroupId { get; set; } // 0x10
        [Key(1)]
        public int RankLowerLimit { get; set; } // 0x14
        [Key(2)]
        public int PvpWeeklyRankRewardGroupId { get; set; } // 0x18
    }
}