using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBigHuntScheduleTable : TableBase<EntityMBigHuntSchedule>
    {
        private readonly Func<EntityMBigHuntSchedule, int> primaryIndexSelector;

        public EntityMBigHuntScheduleTable(EntityMBigHuntSchedule[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.BigHuntScheduleId;
        }
        
        public EntityMBigHuntSchedule FindByBigHuntScheduleId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
