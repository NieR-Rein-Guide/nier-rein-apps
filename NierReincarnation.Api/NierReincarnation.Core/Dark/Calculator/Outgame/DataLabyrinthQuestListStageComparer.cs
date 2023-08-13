using NierReincarnation.Core.Dark.View.UserInterface.Outgame;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public sealed class DataLabyrinthQuestListStageComparer : IComparer<DataLabyrinthQuestListStage>
{
    public static readonly DataLabyrinthQuestListStageComparer InstanceAscending = new(true);

    public static readonly DataLabyrinthQuestListStageComparer InstanceDescending = new(false);
    private readonly bool _ascending;

    private DataLabyrinthQuestListStageComparer(bool ascending)
    {
        _ascending = ascending;
    }

    public int Compare(DataLabyrinthQuestListStage x, DataLabyrinthQuestListStage y)
    {
        if (!_ascending)
        {
            if (y != null && x != null)
                return y.StageSortOrder - x.StageSortOrder;
        }
        else
        {
            if (x != null && y != null)
                return x.StageSortOrder - y.StageSortOrder;
        }

        throw new ArgumentNullException();
    }
}
