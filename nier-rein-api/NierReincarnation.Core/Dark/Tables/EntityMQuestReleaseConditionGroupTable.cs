using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMQuestReleaseConditionGroupTable : TableBase<EntityMQuestReleaseConditionGroup> // TypeDefIndex: 12161
    {
        // Fields
        private readonly Func<EntityMQuestReleaseConditionGroup, ValueTuple<int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C593E0 Offset: 0x2C593E0 VA: 0x2C593E0
        public EntityMQuestReleaseConditionGroupTable(EntityMQuestReleaseConditionGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.QuestReleaseConditionGroupId, group.SortOrder);
        }

        // RVA: 0x2C594E0 Offset: 0x2C594E0 VA: 0x2C594E0
        public RangeView<EntityMQuestReleaseConditionGroup> FindRangeByQuestReleaseConditionGroupIdAndSortOrder(
            ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
        }
    }
}
