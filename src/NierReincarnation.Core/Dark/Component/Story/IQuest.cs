namespace NierReincarnation.Core.Dark.Component.Story;

public interface IQuest
{
    EntityMQuest EntityQuest { get; }

    int ChapterId { get; }

    int QuestSequenceSortOrder { get; }

    int QuestId { get; }

    int QuestBonusId { get; }

    bool IsRunInTheBackground { get; }

    DifficultyType DifficultyType { get; }

    QuestType QuestType { get; }
}
