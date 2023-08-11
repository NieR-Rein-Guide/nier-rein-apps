using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_costume_collection_bonus")]
    public class EntityMCostumeCollectionBonus
    {
        [Key(0)]
        public int CollectionBonusId { get; set; }

        [Key(1)]
        public int CollectionBonusTextId { get; set; }

        [Key(2)]
        public int CollectionBonusGroupId { get; set; }

        [Key(3)]
        public int CollectionBonusQuestAssignmentGroupId { get; set; }

        [Key(4)]
        public int CollectionBonusEffectId { get; set; }

        [Key(5)]
        public long StartDatetime { get; set; }

        [Key(6)]
        public long EndDatetime { get; set; }

        [Key(7)]
        public int GroupingId { get; set; }
    }
}
