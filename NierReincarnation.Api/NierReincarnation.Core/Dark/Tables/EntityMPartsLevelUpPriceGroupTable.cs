using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPartsLevelUpPriceGroupTable : TableBase<EntityMPartsLevelUpPriceGroup>
    {
        private readonly Func<EntityMPartsLevelUpPriceGroup, (int, int)> primaryIndexSelector;

        public EntityMPartsLevelUpPriceGroupTable(EntityMPartsLevelUpPriceGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.PartsLevelUpPriceGroupId, element.LevelLowerLimit);
        }

        public EntityMPartsLevelUpPriceGroup FindByPartsLevelUpPriceGroupIdAndLevelLowerLimit(ValueTuple<int, int> key) =>
            FindUniqueCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key);
    }
}
