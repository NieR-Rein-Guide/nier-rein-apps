using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserBigHuntProgressStatusTable : TableBase<EntityIUserBigHuntProgressStatus>
    {
        private readonly Func<EntityIUserBigHuntProgressStatus, long> primaryIndexSelector;

        public EntityIUserBigHuntProgressStatusTable(EntityIUserBigHuntProgressStatus[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.UserId;
        }

        public EntityIUserBigHuntProgressStatus FindByUserId(long key) => FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key);
    }
}
