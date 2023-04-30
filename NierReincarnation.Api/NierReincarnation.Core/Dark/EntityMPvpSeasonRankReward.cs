using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_pvp_season_rank_reward")]
    public class EntityMPvpSeasonRankReward
    {
        [Key(0)]
        public int RankLowerLimit { get; set; } // 0x10

        [Key(1)]
        public int PvpSeasonRankRewardGroupId { get; set; } // 0x14
    }
}
