using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_catalog_term")]
public class EntityMCatalogTerm
{
    [Key(0)] // RVA: 0x1DD6D24 Offset: 0x1DD6D24 VA: 0x1DD6D24
    public int CatalogTermId { get; set; }

    [Key(1)] // RVA: 0x1DD6D64 Offset: 0x1DD6D64 VA: 0x1DD6D64
    public long StartDatetime { get; set; }
}
