using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeAwakenMaterialGroupTable : TableBase<EntityMCostumeAwakenMaterialGroup>
    {
        private readonly Func<EntityMCostumeAwakenMaterialGroup, (int, int)> primaryIndexSelector;

        public EntityMCostumeAwakenMaterialGroupTable(EntityMCostumeAwakenMaterialGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.CostumeAwakenMaterialGroupId, element.MaterialId);
        }

        public RangeView<EntityMCostumeAwakenMaterialGroup> FindRangeByCostumeAwakenMaterialGroupIdAndMaterialId(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
            FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
    }
}
