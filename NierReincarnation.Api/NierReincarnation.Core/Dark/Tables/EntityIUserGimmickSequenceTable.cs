using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserGimmickSequenceTable : TableBase<EntityIUserGimmickSequence>
{
    private readonly Func<EntityIUserGimmickSequence, (long, int)> primaryIndexSelector;

    public EntityIUserGimmickSequenceTable(EntityIUserGimmickSequence[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.GimmickSequenceScheduleId);
    }

    public EntityIUserGimmickSequence FindByUserId((long, int) key)
    {
        return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key);
    }
}
