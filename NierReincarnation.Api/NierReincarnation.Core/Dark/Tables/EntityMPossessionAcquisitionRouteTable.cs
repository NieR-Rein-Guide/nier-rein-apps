using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPossessionAcquisitionRouteTable : TableBase<EntityMPossessionAcquisitionRoute>
    {
        private readonly Func<EntityMPossessionAcquisitionRoute, (PossessionType, int, int)> primaryIndexSelector;

        public EntityMPossessionAcquisitionRouteTable(EntityMPossessionAcquisitionRoute[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.PossessionType, element.PossessionId, element.SortOrder);
        }

        public RangeView<EntityMPossessionAcquisitionRoute> FindRangeByPossessionTypeAndPossessionIdAndSortOrder(ValueTuple<PossessionType, int, int> min, ValueTuple<PossessionType, int, int> max, bool ascendant = true) =>
            FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(PossessionType, int, int)>.Default, min, max, ascendant);
    }
}
