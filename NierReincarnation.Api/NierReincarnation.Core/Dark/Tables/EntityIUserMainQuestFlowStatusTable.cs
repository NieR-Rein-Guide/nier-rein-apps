using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserMainQuestFlowStatusTable : TableBase<EntityIUserMainQuestFlowStatus>
    {
        private readonly Func<EntityIUserMainQuestFlowStatus, long> primaryIndexSelector;

        public EntityIUserMainQuestFlowStatusTable(EntityIUserMainQuestFlowStatus[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.UserId;
        }

        public EntityIUserMainQuestFlowStatus FindByUserId(long key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key); }
    }
}
