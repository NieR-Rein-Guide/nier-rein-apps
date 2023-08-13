namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame;

public sealed class DataLabyrinthQuestListQuest
{
    public int QuestId { get; }

    public int QuestSortOrder { get; }

    public DataLabyrinthQuestListQuest(int questId, int questSortOrder)
    {
        QuestId = questId;
        QuestSortOrder = questSortOrder;
    }
}
