using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPartsSeriesTable : TableBase<EntityMPartsSeries>
    {
        private readonly Func<EntityMPartsSeries, int> primaryIndexSelector;

        public EntityMPartsSeriesTable(EntityMPartsSeries[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.PartsSeriesId;
        }

        public EntityMPartsSeries FindByPartsSeriesId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
