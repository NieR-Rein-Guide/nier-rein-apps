using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMEventQuestDailyGroupTable : TableBase<EntityMEventQuestDailyGroup>
{
    private readonly Func<EntityMEventQuestDailyGroup, int> primaryIndexSelector;

    public EntityMEventQuestDailyGroupTable(EntityMEventQuestDailyGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.EventQuestDailyGroupId;
    }
}
