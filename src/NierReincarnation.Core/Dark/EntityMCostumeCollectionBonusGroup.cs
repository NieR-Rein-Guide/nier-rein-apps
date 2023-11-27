using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeCollectionBonusGroup))]
public class EntityMCostumeCollectionBonusGroup
{
    [Key(0)]
    public int CollectionBonusGroupId { get; set; }

    [Key(1)]
    public int CostumeId { get; set; }

    [Key(2)]
    public int SortOrder { get; set; }
}
