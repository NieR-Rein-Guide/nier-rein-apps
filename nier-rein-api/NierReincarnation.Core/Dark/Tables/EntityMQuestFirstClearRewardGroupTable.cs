using System;
using System.Collections.Generic;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMQuestFirstClearRewardGroupTable : TableBase<EntityMQuestFirstClearRewardGroup> // TypeDefIndex: 12141
    {
        // Fields
        private readonly Func<EntityMQuestFirstClearRewardGroup, ValueTuple<int, QuestFirstClearRewardType, int>> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C57D7C Offset: 0x2C57D7C VA: 0x2C57D7C
        public EntityMQuestFirstClearRewardGroupTable(EntityMQuestFirstClearRewardGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = group => (group.QuestFirstClearRewardGroupId, group.QuestFirstClearRewardType, group.SortOrder);
        }

        // RVA: 0x2C57E7C Offset: 0x2C57E7C VA: 0x2C57E7C
        public RangeView<EntityMQuestFirstClearRewardGroup> FindRangeByQuestFirstClearRewardGroupIdAndQuestFirstClearRewardTypeAndSortOrder(ValueTuple<int, QuestFirstClearRewardType, int> min, ValueTuple<int, QuestFirstClearRewardType, int> max, bool ascendant = true)
        {
            return FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, QuestFirstClearRewardType, int)>.Default, min, max, ascendant);
        }
    }
}
