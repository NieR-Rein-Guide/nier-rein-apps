using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame;

class DataOutgameMemoryStatusSubInfo
{
    public int StatusIndex { get; }
    public int Level { get; }
    public StatusKindType StatusKindType { get; }
    public StatusCalculationType StatusCalculationType { get; }
    public int StatusChangeValue { get; }

    public DataOutgameMemoryStatusSubInfo(int statusIndex, int level, StatusKindType statusKindType, StatusCalculationType calculationType, int changeValue)
    {
        StatusIndex = statusIndex;
        Level = level;
        StatusKindType = statusKindType;
        StatusCalculationType = calculationType;
        StatusChangeValue = changeValue;
    }
}
