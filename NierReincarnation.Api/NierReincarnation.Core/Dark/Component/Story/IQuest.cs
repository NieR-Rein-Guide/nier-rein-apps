using NierReincarnation.Core.Dark.Generated.Type;

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

    //// RVA: -1 Offset: -1 Slot: 0
    //public abstract EntityMQuest get_EntityQuest();

    //// RVA: -1 Offset: -1 Slot: 1
    //public abstract int get_ChapterId();

    //// RVA: -1 Offset: -1 Slot: 2
    //public abstract int get_QuestSequenceSortOrder();

    //// RVA: -1 Offset: -1 Slot: 3
    //public abstract int get_QuestId();

    //// RVA: -1 Offset: -1 Slot: 4
    //public abstract int get_QuestBonusId();

    //// RVA: -1 Offset: -1 Slot: 5
    //public abstract bool get_IsRunInTheBackground();

    //// RVA: -1 Offset: -1 Slot: 6
    //public abstract int get_DifficultyType();

    //// RVA: -1 Offset: -1 Slot: 7
    //public abstract QuestType get_QuestType();
	}
