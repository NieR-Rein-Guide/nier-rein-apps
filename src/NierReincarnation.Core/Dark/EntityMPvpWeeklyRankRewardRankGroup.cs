using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMPvpWeeklyRankRewardRankGroup))]
public class EntityMPvpWeeklyRankRewardRankGroup
{
    [Key(0)]
    public int PvpWeeklyRankRewardRankGroupId { get; set; }

    [Key(1)]
    public int RankLowerLimit { get; set; }

    [Key(2)]
    public int PvpWeeklyRankRewardGroupId { get; set; }
}
