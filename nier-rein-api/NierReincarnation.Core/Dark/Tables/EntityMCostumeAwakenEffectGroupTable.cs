using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeAwakenEffectGroupTable : TableBase<EntityMCostumeAwakenEffectGroup>
    {
        private readonly Func<EntityMCostumeAwakenEffectGroup, (int,int,int)> primaryIndexSelector;
        private readonly Func<EntityMCostumeAwakenEffectGroup, (int,int)> secondaryIndexSelector;

        public EntityMCostumeAwakenEffectGroupTable(EntityMCostumeAwakenEffectGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CostumeAwakenEffectGroupId,element.AwakenStep,element.CostumeAwakenEffectType);
            secondaryIndexSelector = element => (element.CostumeAwakenEffectGroupId,element.CostumeAwakenEffectType);
        }
        
        public RangeView<EntityMCostumeAwakenEffectGroup> FindRangeByCostumeAwakenEffectGroupIdAndAwakenStepAndCostumeAwakenEffectType(ValueTuple<int, int, int> min, ValueTuple<int, int, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int,int,int)>.Default, min, max, ascendant); }

	
        public RangeView<EntityMCostumeAwakenEffectGroup> FindByCostumeAwakenEffectGroupIdAndCostumeAwakenEffectType(ValueTuple<int, int> key) { return FindManyCore(data, secondaryIndexSelector, Comparer<(int,int)>.Default, key); }

	
        public RangeView<EntityMCostumeAwakenEffectGroup> FindRangeByCostumeAwakenEffectGroupIdAndCostumeAwakenEffectType(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, secondaryIndexSelector, Comparer<(int,int)>.Default, min, max, ascendant); }

    }
}
