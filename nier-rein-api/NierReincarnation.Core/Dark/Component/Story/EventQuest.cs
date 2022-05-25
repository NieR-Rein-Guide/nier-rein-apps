using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Component.Story
{
    class EventQuest : IUniqueQuest<EntityMEventQuestChapter, EntityMEventQuestSequenceGroup, EntityMEventQuestSequence>
    {
        public EntityMEventQuestChapter EntityQuestChapter { get; set; }
        public EntityMEventQuestSequenceGroup EntityQuestSequenceGroup { get; set; }
        public EntityMEventQuestSequence EntityQuestSequence { get; set; }
        public EntityMQuest EntityQuest { get; set; }

        public int ChapterId => EntityQuestChapter.EventQuestChapterId;
        public int QuestSequenceSortOrder => EntityQuestSequence.SortOrder;
        public int QuestId => EntityQuest.QuestId;
        public int QuestBonusId => EntityQuest.QuestBonusId;
        public bool IsRunInTheBackground { get; }
        public DifficultyType DifficultyType => EntityQuestSequenceGroup.DifficultyType;
        public QuestType QuestType => QuestType.EVENT_QUEST;

        public EventQuest(EntityMEventQuestChapter questChapter, EntityMEventQuestSequenceGroup questSequenceGroups,
            EntityMEventQuestSequence questSequence, EntityMQuest quest)
        {
            EntityQuestChapter = questChapter;
            EntityQuestSequenceGroup = questSequenceGroups;
            EntityQuestSequence = questSequence;
            EntityQuest = quest;
        }
    }
}
