using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMQuestMissionGroupTable : TableBase<EntityMQuestMissionGroup> // TypeDefIndex: 12145
    {
        // Fields
        private readonly Func<EntityMQuestMissionGroup, ValueTuple<int, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C582A4 Offset: 0x2C582A4 VA: 0x2C582A4
        public EntityMQuestMissionGroupTable(EntityMQuestMissionGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.QuestMissionGroupId, group.SortOrder);
        }

        // RVA: 0x2C583A4 Offset: 0x2C583A4 VA: 0x2C583A4
        public RangeView<EntityMQuestMissionGroup> FindRangeByQuestMissionGroupIdAndSortOrder(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
        }
    }
}
