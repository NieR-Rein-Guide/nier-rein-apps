using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeAwakenItemAcquireTable : TableBase<EntityMCostumeAwakenItemAcquire>
    {
        private readonly Func<EntityMCostumeAwakenItemAcquire, (int,int,int)> primaryIndexSelector;

        public EntityMCostumeAwakenItemAcquireTable(EntityMCostumeAwakenItemAcquire[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CostumeAwakenItemAcquireId,element.PossessionType,element.PossessionId);
        }
        
        public RangeView<EntityMCostumeAwakenItemAcquire> FindRangeByCostumeAwakenItemAcquireIdAndPossessionTypeAndPossessionId(ValueTuple<int, int, int> min, ValueTuple<int, int, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int,int,int)>.Default, min, max, ascendant); }

    }
}
