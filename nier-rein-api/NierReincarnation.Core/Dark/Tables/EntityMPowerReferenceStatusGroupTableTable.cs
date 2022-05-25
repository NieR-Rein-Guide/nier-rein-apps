using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMPowerReferenceStatusGroupTable : TableBase<EntityMPowerReferenceStatusGroup> // TypeDefIndex: 12085
    {
        // Fields
        private readonly Func<EntityMPowerReferenceStatusGroup, ValueTuple<int, StatusKindType>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C543A4 Offset: 0x2C543A4 VA: 0x2C543A4
        public EntityMPowerReferenceStatusGroupTable(EntityMPowerReferenceStatusGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.PowerReferenceStatusGroupId, group.ReferenceStatusType);
        }

        // RVA: 0x2C544A4 Offset: 0x2C544A4 VA: 0x2C544A4
        public RangeView<EntityMPowerReferenceStatusGroup> FindRangeByPowerReferenceStatusGroupIdAndReferenceStatusType(ValueTuple<int, StatusKindType> min, ValueTuple<int, StatusKindType> max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, StatusKindType)>.Default, min, max, ascendant);
        }
    }
}
