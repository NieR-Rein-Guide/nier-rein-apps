using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserPvpWeeklyResultTable : TableBase<EntityIUserPvpWeeklyResult>
    {
        private readonly Func<EntityIUserPvpWeeklyResult, (long, long)> primaryIndexSelector;

        public EntityIUserPvpWeeklyResultTable(EntityIUserPvpWeeklyResult[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.PvpWeeklyVersion);
        }
    }
}
