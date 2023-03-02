using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeAwakenStepMaterialGroupTable : TableBase<EntityMCostumeAwakenStepMaterialGroup>
    {
        private readonly Func<EntityMCostumeAwakenStepMaterialGroup, (int,int)> primaryIndexSelector;

        public EntityMCostumeAwakenStepMaterialGroupTable(EntityMCostumeAwakenStepMaterialGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CostumeAwakenStepMaterialGroupId,element.AwakenStepLowerLimit);
        }
        
        public RangeView<EntityMCostumeAwakenStepMaterialGroup> FindRangeByCostumeAwakenStepMaterialGroupIdAndAwakenStepLowerLimit(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, min, max, ascendant); }

    }
}
