using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_pvp_weekly_rank_reward_rank_group")]
public class EntityMPvpWeeklyRankRewardRankGroup
{
    [Key(0)]
    public int PvpWeeklyRankRewardRankGroupId { get; set; }

    [Key(1)]
    public int RankLowerLimit { get; set; }

    [Key(2)]
    public int PvpWeeklyRankRewardGroupId { get; set; }
}
