using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserQuestAutoOrbitTable : TableBase<EntityIUserQuestAutoOrbit>
{
    private readonly Func<EntityIUserQuestAutoOrbit, long> primaryIndexSelector;

    public EntityIUserQuestAutoOrbitTable(EntityIUserQuestAutoOrbit[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.UserId;
    }

    public EntityIUserQuestAutoOrbit FindByUserId(long key) => FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key);
}
