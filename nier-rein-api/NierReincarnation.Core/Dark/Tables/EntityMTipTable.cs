using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMTipTable : TableBase<EntityMTip>
    {
        private readonly Func<EntityMTip, int> primaryIndexSelector;

        public EntityMTipTable(EntityMTip[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.TipId;
        }
        
        public EntityMTip FindByTipId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
