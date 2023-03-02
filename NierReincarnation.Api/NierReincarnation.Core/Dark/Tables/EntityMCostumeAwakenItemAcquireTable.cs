using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeAwakenItemAcquireTable : TableBase<EntityMCostumeAwakenItemAcquire>
    {
        private readonly Func<EntityMCostumeAwakenItemAcquire, (int, PossessionType, int)> primaryIndexSelector;

        public EntityMCostumeAwakenItemAcquireTable(EntityMCostumeAwakenItemAcquire[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CostumeAwakenItemAcquireId,element.PossessionType,element.PossessionId);
        }
        
        public RangeView<EntityMCostumeAwakenItemAcquire> FindRangeByCostumeAwakenItemAcquireIdAndPossessionTypeAndPossessionId(ValueTuple<int, PossessionType, int> min, ValueTuple<int, PossessionType, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, PossessionType, int)>.Default, min, max, ascendant); }

    }
}
