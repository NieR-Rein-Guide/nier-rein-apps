using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCompanionEnhancementMaterial))]
public class EntityMCompanionEnhancementMaterial
{
    [Key(0)]
    public int CompanionCategoryType { get; set; }

    [Key(1)]
    public int Level { get; set; }

    [Key(2)]
    public int MaterialId { get; set; }

    [Key(3)]
    public int Count { get; set; }

    [Key(4)]
    public int SortOrder { get; set; }
}
