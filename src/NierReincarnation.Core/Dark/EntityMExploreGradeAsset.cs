using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMExploreGradeAsset))]
public class EntityMExploreGradeAsset
{
    [Key(0)]
    public int ExploreGradeId { get; set; }

    [Key(1)]
    public int AssetGradeIconId { get; set; }
}
