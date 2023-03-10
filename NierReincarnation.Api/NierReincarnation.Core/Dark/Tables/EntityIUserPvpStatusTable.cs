using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserPvpStatusTable : TableBase<EntityIUserPvpStatus>
    {
        private readonly Func<EntityIUserPvpStatus, long> primaryIndexSelector;

        public EntityIUserPvpStatusTable(EntityIUserPvpStatus[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.UserId;
        }

        public EntityIUserPvpStatus FindByUserId(long key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key); }
    }
}