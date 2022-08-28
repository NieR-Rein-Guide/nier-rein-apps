using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_collection_bonus")]
    public class EntityMCostumeCollectionBonus
    {
        [Key(0)]
        public int CollectionBonusId { get; set; } // 0x10
        [Key(1)]
        public int CollectionBonusTextId { get; set; } // 0x14
        [Key(2)]
        public int CollectionBonusGroupId { get; set; } // 0x18
        [Key(3)]
        public int CollectionBonusQuestAssignmentGroupId { get; set; } // 0x1C
        [Key(4)]
        public int CollectionBonusEffectId { get; set; } // 0x20
        [Key(5)]
        public long StartDatetime { get; set; } // 0x28
        [Key(6)]
        public long EndDatetime { get; set; } // 0x30
        [Key(7)]
        public int GroupingId { get; set; } // 0x38
    }
}