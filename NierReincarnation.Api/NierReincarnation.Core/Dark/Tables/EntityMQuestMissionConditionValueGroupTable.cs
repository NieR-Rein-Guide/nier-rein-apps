using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestMissionConditionValueGroupTable : TableBase<EntityMQuestMissionConditionValueGroup>
{
    private readonly Func<EntityMQuestMissionConditionValueGroup, (int, int)> primaryIndexSelector;

    public EntityMQuestMissionConditionValueGroupTable(EntityMQuestMissionConditionValueGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.QuestMissionConditionValueGroupId, element.SortOrder);
    }

    public RangeView<EntityMQuestMissionConditionValueGroup> FindRangeByQuestMissionConditionValueGroupIdAndSortOrder(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
}
