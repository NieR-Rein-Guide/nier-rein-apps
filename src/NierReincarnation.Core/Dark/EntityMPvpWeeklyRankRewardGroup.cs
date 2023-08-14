using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_pvp_weekly_rank_reward_group")]
public class EntityMPvpWeeklyRankRewardGroup
{
    [Key(0)]
    public int PvpWeeklyRankRewardGroupId { get; set; }

    [Key(1)]
    public int PvpRewardId { get; set; }

    [Key(2)]
    public int SortOrder { get; set; }
}
