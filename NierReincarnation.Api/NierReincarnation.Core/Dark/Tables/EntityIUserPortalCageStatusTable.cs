using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserPortalCageStatusTable : TableBase<EntityIUserPortalCageStatus>
    {
        private readonly Func<EntityIUserPortalCageStatus, long> primaryIndexSelector;

        public EntityIUserPortalCageStatusTable(EntityIUserPortalCageStatus[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.UserId;
        }

        public EntityIUserPortalCageStatus FindByUserId(long key) => FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key);
    }
}
