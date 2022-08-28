using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMGimmickGroupEventLogTable : TableBase<EntityMGimmickGroupEventLog>
    {
        private readonly Func<EntityMGimmickGroupEventLog, int> primaryIndexSelector;

        public EntityMGimmickGroupEventLogTable(EntityMGimmickGroupEventLog[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.GimmickGroupId;
        }
        
        public bool TryFindByGimmickGroupId(int key, out EntityMGimmickGroupEventLog result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
