using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPowerReferenceStatusGroupTable : TableBase<EntityMPowerReferenceStatusGroup>
    {
        private readonly Func<EntityMPowerReferenceStatusGroup, (int, StatusKindType)> primaryIndexSelector;

        public EntityMPowerReferenceStatusGroupTable(EntityMPowerReferenceStatusGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.PowerReferenceStatusGroupId, element.ReferenceStatusType);
        }

        public RangeView<EntityMPowerReferenceStatusGroup> FindRangeByPowerReferenceStatusGroupIdAndReferenceStatusType(ValueTuple<int, StatusKindType> min, ValueTuple<int, StatusKindType> max, bool ascendant = true) =>
            FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, StatusKindType)>.Default, min, max, ascendant);
    }
}
