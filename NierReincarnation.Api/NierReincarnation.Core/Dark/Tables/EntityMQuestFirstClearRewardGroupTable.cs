using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestFirstClearRewardGroupTable : TableBase<EntityMQuestFirstClearRewardGroup>
{
    private readonly Func<EntityMQuestFirstClearRewardGroup, (int, QuestFirstClearRewardType, int)> primaryIndexSelector;

    public EntityMQuestFirstClearRewardGroupTable(EntityMQuestFirstClearRewardGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.QuestFirstClearRewardGroupId, element.QuestFirstClearRewardType, element.SortOrder);
    }

    public RangeView<EntityMQuestFirstClearRewardGroup> FindRangeByQuestFirstClearRewardGroupIdAndQuestFirstClearRewardTypeAndSortOrder(ValueTuple<int, QuestFirstClearRewardType, int> min, ValueTuple<int, QuestFirstClearRewardType, int> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, QuestFirstClearRewardType, int)>.Default, min, max, ascendant);
}
