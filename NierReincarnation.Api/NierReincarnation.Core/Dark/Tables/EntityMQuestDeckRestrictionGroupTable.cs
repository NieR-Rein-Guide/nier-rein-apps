using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMQuestDeckRestrictionGroupTable : TableBase<EntityMQuestDeckRestrictionGroup>
{
    private readonly Func<EntityMQuestDeckRestrictionGroup, (int, int)> primaryIndexSelector;

    public EntityMQuestDeckRestrictionGroupTable(EntityMQuestDeckRestrictionGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.QuestDeckRestrictionGroupId, element.SlotNumber);
    }

    public RangeView<EntityMQuestDeckRestrictionGroup> FindRangeByQuestDeckRestrictionGroupIdAndSlotNumber(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
}
