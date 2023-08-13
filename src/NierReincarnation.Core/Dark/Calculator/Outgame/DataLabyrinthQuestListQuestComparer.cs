using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public sealed class DataLabyrinthQuestListQuestComparer : IComparer<DataLabyrinthQuestListQuest>
{
    public static readonly DataLabyrinthQuestListQuestComparer InstanceAscending = new(true);

    public static readonly DataLabyrinthQuestListQuestComparer InstanceDescending = new(false);
    private readonly bool _ascending;

    private DataLabyrinthQuestListQuestComparer(bool ascending)
    {
        _ascending = ascending;
    }

    public int Compare(DataLabyrinthQuestListQuest x, DataLabyrinthQuestListQuest y)
    {
        if (!_ascending)
        {
            if (y != null && x != null)
                return y.QuestSortOrder - x.QuestSortOrder;
        }
        else
        {
            if (x != null && y != null)
                return x.QuestSortOrder - y.QuestSortOrder;
        }

        throw new ArgumentNullException();
    }
}
