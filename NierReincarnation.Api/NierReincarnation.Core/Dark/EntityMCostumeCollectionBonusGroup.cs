using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_collection_bonus_group")]
    public class EntityMCostumeCollectionBonusGroup
    {
        [Key(0)]
        public int CollectionBonusGroupId { get; set; } // 0x10
        [Key(1)]
        public int CostumeId { get; set; } // 0x14
        [Key(2)]
        public int SortOrder { get; set; } // 0x18
    }
}