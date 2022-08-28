using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMAssetCalculatorTable : TableBase<EntityMAssetCalculator>
    {
        private readonly Func<EntityMAssetCalculator, int> primaryIndexSelector;

        public EntityMAssetCalculatorTable(EntityMAssetCalculator[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.AssetCalculatorId;
        }
        
        public EntityMAssetCalculator FindByAssetCalculatorId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
