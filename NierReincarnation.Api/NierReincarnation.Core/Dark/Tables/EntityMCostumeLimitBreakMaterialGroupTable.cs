using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeLimitBreakMaterialGroupTable : TableBase<EntityMCostumeLimitBreakMaterialGroup>
    {
        private readonly Func<EntityMCostumeLimitBreakMaterialGroup, (int,int)> primaryIndexSelector;

        public EntityMCostumeLimitBreakMaterialGroupTable(EntityMCostumeLimitBreakMaterialGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CostumeLimitBreakMaterialGroupId,element.MaterialId);
        }
        
        public RangeView<EntityMCostumeLimitBreakMaterialGroup> FindRangeByCostumeLimitBreakMaterialGroupIdAndMaterialId(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, min, max, ascendant); }

    }
}
