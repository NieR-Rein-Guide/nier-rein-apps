using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMEvaluateConditionTable : TableBase<EntityMEvaluateCondition>
    {
        private readonly Func<EntityMEvaluateCondition, int> primaryIndexSelector;

        public EntityMEvaluateConditionTable(EntityMEvaluateCondition[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.EvaluateConditionId;
        }
        
        public EntityMEvaluateCondition FindByEvaluateConditionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
