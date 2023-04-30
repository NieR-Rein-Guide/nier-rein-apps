using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_pvp_season_rank_reward_per_season")]
    public class EntityMPvpSeasonRankRewardPerSeason
    {
        [Key(0)]
        public int RankLowerLimit { get; set; } // 0x10

        [Key(1)]
        public int PvpSeasonId { get; set; } // 0x14

        [Key(2)]
        public int PvpSeasonRankRewardGroupId { get; set; } // 0x18
    }
}
