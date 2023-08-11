using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMPvpGradeGroupTable : TableBase<EntityMPvpGradeGroup>
{
    private readonly Func<EntityMPvpGradeGroup, (int, int)> primaryIndexSelector;

    public EntityMPvpGradeGroupTable(EntityMPvpGradeGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.PvpGradeGroupId, element.PvpGradeId);
    }

    public RangeView<EntityMPvpGradeGroup> FindRangeByPvpGradeGroupIdAndPvpGradeId(ValueTuple<int, int> min, ValueTuple<int, int> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, min, max, ascendant);
}
