using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityIUserExploreScore))]
public class EntityIUserExploreScore
{
    [Key(0)]
    public long UserId { get; set; }

    [Key(1)]
    public int ExploreId { get; set; }

    [Key(2)]
    public int MaxScore { get; set; }

    [Key(3)]
    public long MaxScoreUpdateDatetime { get; set; }

    [Key(4)]
    public long LatestVersion { get; set; }
}
