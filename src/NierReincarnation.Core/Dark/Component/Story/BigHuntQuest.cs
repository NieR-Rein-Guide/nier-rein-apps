using NierReincarnation.Core.Dark.Component.Story.Ghost;
using NierReincarnation.Core.Dark.Types;

namespace NierReincarnation.Core.Dark.Component.Story;

public class BigHuntQuest : IUniqueQuest<EntityMBigHuntStoryQuestChapter, EntityMBigHuntStoryQuestSequenceGroup, EntityMBigHuntStoryQuestSequence>
{
    private EntityMBigHuntStoryQuestChapter EntityQuestChapter { get; set; }

    public EntityMBigHuntStoryQuestSequenceGroup EntityQuestSequenceGroup { get; set; }

    public EntityMBigHuntStoryQuestSequence EntityQuestSequence { get; set; }

    public EntityMQuest EntityQuest { get; set; }

    public int ChapterId => BigHunt.FixChapterId;

    public int QuestSequenceSortOrder => BigHunt.FixSortOrder;

    public int QuestId => EntityQuest.QuestId;

    public int QuestBonusId => EntityQuest.QuestBonusId;

    public bool IsRunInTheBackground => EntityQuest.IsRunInTheBackground;

    public DifficultyType DifficultyType => BigHunt.FixQuestDifficultyType;

    public QuestType QuestType => QuestType.BIG_HUNT_QUEST;

    public BigHuntQuest(EntityMBigHuntStoryQuestChapter questChapter, EntityMBigHuntStoryQuestSequenceGroup questSequenceGroups,
        EntityMBigHuntStoryQuestSequence questSequence, EntityMQuest quest)
    {
        EntityQuestChapter = questChapter;
        EntityQuestSequenceGroup = questSequenceGroups;
        EntityQuestSequence = questSequence;
        EntityQuest = quest;
    }
}
