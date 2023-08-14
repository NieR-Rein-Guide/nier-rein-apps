using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_catalog_companion")]
public class EntityMCatalogCompanion
{
    [Key(0)]
    public int CompanionId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int CatalogTermId { get; set; }
}
