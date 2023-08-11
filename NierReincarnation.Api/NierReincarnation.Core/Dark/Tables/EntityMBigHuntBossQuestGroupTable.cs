using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBigHuntBossQuestGroupTable : TableBase<EntityMBigHuntBossQuestGroup>
{
    private readonly Func<EntityMBigHuntBossQuestGroup, (int, int)> primaryIndexSelector;

    public EntityMBigHuntBossQuestGroupTable(EntityMBigHuntBossQuestGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.BigHuntBossQuestGroupId, element.SortOrder);
    }

    public RangeView<EntityMBigHuntBossQuestGroup> FindRangeByBigHuntBossQuestGroupIdAndSortOrder(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
}
