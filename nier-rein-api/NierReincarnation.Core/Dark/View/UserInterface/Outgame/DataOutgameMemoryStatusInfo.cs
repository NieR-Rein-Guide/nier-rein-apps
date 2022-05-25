using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame
{
    class DataOutgameMemoryStatusInfo
    {
        // 0x10
        public int Level { get; }
        // 0x14
        public int PartsStatusMainId { get; }
        // 0x18
        public IList<DataOutgameMemoryStatusSubInfo> PartsStatusSubs { get; }

        public DataOutgameMemoryStatusInfo(int level, int partsStatusMainId, IList<DataOutgameMemoryStatusSubInfo> partsStatusSubs)
        {
            Level = level;
            PartsStatusMainId = partsStatusMainId;
            PartsStatusSubs = partsStatusSubs;
        }
    }
}
