using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_catalog_term")]
public class EntityMCatalogTerm
{
    [Key(0)]
    public int CatalogTermId { get; set; }

    [Key(1)]
    public long StartDatetime { get; set; }
}
