using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMGimmickSequenceScheduleTable : TableBase<EntityMGimmickSequenceSchedule>
{
    private readonly Func<EntityMGimmickSequenceSchedule, int> primaryIndexSelector;

    public EntityMGimmickSequenceScheduleTable(EntityMGimmickSequenceSchedule[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.GimmickSequenceScheduleId;
    }
}
