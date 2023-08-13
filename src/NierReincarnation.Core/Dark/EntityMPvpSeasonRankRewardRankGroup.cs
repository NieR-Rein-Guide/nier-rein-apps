using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_pvp_season_rank_reward_rank_group")]
public class EntityMPvpSeasonRankRewardRankGroup
{
    [Key(0)]
    public int PvpSeasonRankRewardRankGroupId { get; set; }

    [Key(1)]
    public int RankLowerLimit { get; set; }

    [Key(2)]
    public int PvpSeasonRankRewardGroupId { get; set; }
}
