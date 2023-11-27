using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMPvpSeasonRankRewardPerSeason))]
public class EntityMPvpSeasonRankRewardPerSeason
{
    [Key(0)]
    public int RankLowerLimit { get; set; }

    [Key(1)]
    public int PvpSeasonId { get; set; }

    [Key(2)]
    public int PvpSeasonRankRewardGroupId { get; set; }
}
