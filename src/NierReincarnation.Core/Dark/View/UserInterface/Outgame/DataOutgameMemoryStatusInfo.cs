﻿namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame;

public sealed class DataOutgameMemoryStatusInfo
{
    public int Level { get; }

    public int PartsStatusMainId { get; }

    public IList<DataOutgameMemoryStatusSubInfo> PartsStatusSubs { get; }

    public DataOutgameMemoryStatusInfo(int level, int partsStatusMainId, IList<DataOutgameMemoryStatusSubInfo> partsStatusSubs)
    {
        Level = level;
        PartsStatusMainId = partsStatusMainId;
        PartsStatusSubs = partsStatusSubs;
    }
}
