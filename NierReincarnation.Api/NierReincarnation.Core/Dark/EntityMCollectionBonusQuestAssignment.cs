using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_collection_bonus_quest_assignment")]
    public class EntityMCollectionBonusQuestAssignment
    {
        [Key(0)]
        public int CollectionBonusQuestAssignmentId { get; set; }

        [Key(1)]
        public QuestAssignmentType QuestAssignmentType { get; set; }

        [Key(2)]
        public int MainQuestChapterId { get; set; }

        [Key(3)]
        public int EventQuestChapterId { get; set; }

        [Key(4)]
        public int QuestId { get; set; }

        [Key(5)]
        public int SortOrder { get; set; }
    }
}
