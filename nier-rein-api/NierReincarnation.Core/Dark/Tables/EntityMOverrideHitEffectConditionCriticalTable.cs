using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMOverrideHitEffectConditionCriticalTable : TableBase<EntityMOverrideHitEffectConditionCritical>
    {
        private readonly Func<EntityMOverrideHitEffectConditionCritical, int> primaryIndexSelector;

        public EntityMOverrideHitEffectConditionCriticalTable(EntityMOverrideHitEffectConditionCritical[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.OverrideHitEffectConditionId;
        }
        
        public EntityMOverrideHitEffectConditionCritical FindByOverrideHitEffectConditionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
