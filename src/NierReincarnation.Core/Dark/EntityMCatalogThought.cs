using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCatalogThought))]
public class EntityMCatalogThought
{
    [Key(0)]
    public int ThoughtId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public int CatalogTermId { get; set; }
}
