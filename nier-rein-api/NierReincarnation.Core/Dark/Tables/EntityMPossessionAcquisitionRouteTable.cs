using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPossessionAcquisitionRouteTable : TableBase<EntityMPossessionAcquisitionRoute>
    {
        private readonly Func<EntityMPossessionAcquisitionRoute, (int,int,int)> primaryIndexSelector;

        public EntityMPossessionAcquisitionRouteTable(EntityMPossessionAcquisitionRoute[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.PossessionType,element.PossessionId,element.SortOrder);
        }
        
        public RangeView<EntityMPossessionAcquisitionRoute> FindRangeByPossessionTypeAndPossessionIdAndSortOrder(ValueTuple<int, int, int> min, ValueTuple<int, int, int> max, bool ascendant = true) { return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int,int,int)>.Default, min, max, ascendant); }

    }
}
