using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBigHuntScoreRewardGroup))]
public class EntityMBigHuntScoreRewardGroup
{
    [Key(0)]
    public int BigHuntScoreRewardGroupId { get; set; }

    [Key(1)]
    public long NecessaryScore { get; set; }

    [Key(2)]
    public int BigHuntRewardGroupId { get; set; }
}
