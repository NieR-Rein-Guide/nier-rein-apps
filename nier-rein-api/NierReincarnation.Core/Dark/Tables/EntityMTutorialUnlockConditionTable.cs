using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMTutorialUnlockConditionTable : TableBase<EntityMTutorialUnlockCondition>
    {
        private readonly Func<EntityMTutorialUnlockCondition, int> primaryIndexSelector;

        public EntityMTutorialUnlockConditionTable(EntityMTutorialUnlockCondition[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.TutorialType;
        }
        
        public EntityMTutorialUnlockCondition FindByTutorialType(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
