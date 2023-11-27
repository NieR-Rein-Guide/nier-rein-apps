using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCatalogCostume))]
public class EntityMCatalogCostume
{
    [Key(0)]
    public int CostumeId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int CatalogTermId { get; set; }
}
