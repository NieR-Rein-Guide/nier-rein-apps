using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.Component.Story
{
    public class MainQuest : IUniqueQuest<EntityMMainQuestChapter, EntityMMainQuestSequenceGroup, EntityMMainQuestSequence>
    {
        public EntityMMainQuestChapter EntityQuestChapter { get; set; }
        public EntityMMainQuestSequenceGroup EntityQuestSequenceGroup { get; set; }
        public EntityMMainQuestSequence EntityQuestSequence { get; set; }
        public EntityMQuest EntityQuest { get; set; }

        public int ChapterId => EntityQuestChapter.MainQuestChapterId;
        public int QuestSequenceSortOrder => EntityQuestSequence.SortOrder;
        public int QuestId => EntityQuest.QuestId;
        public int QuestBonusId => EntityQuest.QuestBonusId;
        public bool IsRunInTheBackground { get; }
        public DifficultyType DifficultyType => EntityQuestSequenceGroup.DifficultyType;
        public QuestType QuestType => QuestType.MAIN_QUEST;
        public bool IsReplayed { get; }

        public MainQuest(EntityMMainQuestChapter questChapter, EntityMMainQuestSequenceGroup questSequenceGroups,
            EntityMMainQuestSequence questSequence, EntityMQuest quest)
        {
            EntityQuestChapter = questChapter;
            EntityQuestSequenceGroup = questSequenceGroups;
            EntityQuestSequence = questSequence;
            EntityQuest = quest;
        }

        public MainQuest(EntityMMainQuestChapter questChapter, EntityMMainQuestSequenceGroup questSequenceGroups,
            EntityMMainQuestSequence questSequence, EntityMQuest quest, bool isReplayed) : this(questChapter, questSequenceGroups, questSequence, quest)
        {
            IsReplayed = isReplayed;
        }
    }
}
