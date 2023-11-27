using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMPvpSeasonRankRewardGroup))]
public class EntityMPvpSeasonRankRewardGroup
{
    [Key(0)]
    public int PvpSeasonRankRewardGroupId { get; set; }

    [Key(1)]
    public int PvpRewardId { get; set; }

    [Key(2)]
    public int SortOrder { get; set; }
}
