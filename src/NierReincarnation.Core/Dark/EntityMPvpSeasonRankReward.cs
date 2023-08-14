using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_pvp_season_rank_reward")]
public class EntityMPvpSeasonRankReward
{
    [Key(0)]
    public int RankLowerLimit { get; set; }

    [Key(1)]
    public int PvpSeasonRankRewardGroupId { get; set; }
}
