using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMQuestMissionConditionValueGroupTable : TableBase<EntityMQuestMissionConditionValueGroup> // TypeDefIndex: 12143
    {
        // Fields
        private readonly Func<EntityMQuestMissionConditionValueGroup, ValueTuple<int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C58028 Offset: 0x2C58028 VA: 0x2C58028
        public EntityMQuestMissionConditionValueGroupTable(EntityMQuestMissionConditionValueGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.QuestMissionConditionValueGroupId, group.SortOrder);
        }

        // RVA: 0x2C58128 Offset: 0x2C58128 VA: 0x2C58128
        public RangeView<EntityMQuestMissionConditionValueGroup> FindRangeByQuestMissionConditionValueGroupIdAndSortOrder(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
        }
    }
}
