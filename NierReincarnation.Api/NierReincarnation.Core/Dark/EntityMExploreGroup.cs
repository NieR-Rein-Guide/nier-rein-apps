using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_explore_group")]
public class EntityMExploreGroup
{
    [Key(0)]
    public int ExploreGroupId { get; set; }

    [Key(1)]
    public DifficultyType DifficultyType { get; set; }

    [Key(2)]
    public int ExploreId { get; set; }
}
