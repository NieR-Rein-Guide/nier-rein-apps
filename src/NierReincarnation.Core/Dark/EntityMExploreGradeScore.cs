using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMExploreGradeScore))]
public class EntityMExploreGradeScore
{
    [Key(0)]
    public int ExploreId { get; set; }

    [Key(1)]
    public int NecessaryScore { get; set; }

    [Key(2)]
    public int ExploreGradeId { get; set; }
}
