using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMGimmickTable : TableBase<EntityMGimmick>
    {
        private readonly Func<EntityMGimmick, int> primaryIndexSelector;

        public EntityMGimmickTable(EntityMGimmick[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.GimmickId;
        }

        public EntityMGimmick FindByGimmickId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
