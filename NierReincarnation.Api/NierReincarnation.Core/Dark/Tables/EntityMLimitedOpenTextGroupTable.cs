using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMLimitedOpenTextGroupTable : TableBase<EntityMLimitedOpenTextGroup>
{
    private readonly Func<EntityMLimitedOpenTextGroup, (int, int)> primaryIndexSelector;

    public EntityMLimitedOpenTextGroupTable(EntityMLimitedOpenTextGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.LimitedOpenTextGroupId, element.SortOrder);
    }
}
