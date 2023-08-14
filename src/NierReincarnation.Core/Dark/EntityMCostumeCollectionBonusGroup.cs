using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_collection_bonus_group")]
public class EntityMCostumeCollectionBonusGroup
{
    [Key(0)]
    public int CollectionBonusGroupId { get; set; }

    [Key(1)]
    public int CostumeId { get; set; }

    [Key(2)]
    public int SortOrder { get; set; }
}
