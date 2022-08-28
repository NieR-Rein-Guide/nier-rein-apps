using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_collection_bonus_quest_assignment")]
    public class EntityMCollectionBonusQuestAssignment
    {
        [Key(0)]
        public int CollectionBonusQuestAssignmentId { get; set; } // 0x10
        [Key(1)]
        public int QuestAssignmentType { get; set; } // 0x14
        [Key(2)]
        public int MainQuestChapterId { get; set; } // 0x18
        [Key(3)]
        public int EventQuestChapterId { get; set; } // 0x1C
        [Key(4)]
        public int QuestId { get; set; } // 0x20
        [Key(5)]
        public int SortOrder { get; set; } // 0x24
    }
}