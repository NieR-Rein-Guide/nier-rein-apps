using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMExploreUnlockConditionTable : TableBase<EntityMExploreUnlockCondition>
{
    private readonly Func<EntityMExploreUnlockCondition, int> primaryIndexSelector;

    public EntityMExploreUnlockConditionTable(EntityMExploreUnlockCondition[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.ExploreUnlockConditionId;
    }

    public EntityMExploreUnlockCondition FindByExploreUnlockConditionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
