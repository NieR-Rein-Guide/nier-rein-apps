using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMExploreUnlockConditionTable : TableBase<EntityMExploreUnlockCondition>
    {
        private readonly Func<EntityMExploreUnlockCondition, int> primaryIndexSelector;

        public EntityMExploreUnlockConditionTable(EntityMExploreUnlockCondition[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.ExploreUnlockConditionId;
        }
        
        public EntityMExploreUnlockCondition FindByExploreUnlockConditionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
