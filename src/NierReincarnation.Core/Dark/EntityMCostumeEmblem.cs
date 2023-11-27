using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeEmblem))]
public class EntityMCostumeEmblem
{
    [Key(0)]
    public int CostumeEmblemAssetId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }
}
