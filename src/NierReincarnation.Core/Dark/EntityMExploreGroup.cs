using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMExploreGroup))]
public class EntityMExploreGroup
{
    [Key(0)]
    public int ExploreGroupId { get; set; }

    [Key(1)]
    public DifficultyType DifficultyType { get; set; }

    [Key(2)]
    public int ExploreId { get; set; }
}
