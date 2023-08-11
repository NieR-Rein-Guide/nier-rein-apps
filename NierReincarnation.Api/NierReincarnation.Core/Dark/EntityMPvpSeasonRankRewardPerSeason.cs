using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_pvp_season_rank_reward_per_season")]
    public class EntityMPvpSeasonRankRewardPerSeason
    {
        [Key(0)]
        public int RankLowerLimit { get; set; }

        [Key(1)]
        public int PvpSeasonId { get; set; }

        [Key(2)]
        public int PvpSeasonRankRewardGroupId { get; set; }
    }
}
