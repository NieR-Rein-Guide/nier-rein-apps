using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCatalogPartsGroup))]
public class EntityMCatalogPartsGroup
{
    [Key(0)]
    public int PartsGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int CatalogTermId { get; set; }
}
