using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMPvpSeasonRankReward))]
public class EntityMPvpSeasonRankReward
{
    [Key(0)]
    public int RankLowerLimit { get; set; }

    [Key(1)]
    public int PvpSeasonRankRewardGroupId { get; set; }
}
