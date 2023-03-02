using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMOverrideHitEffectConditionDamageAttributeTable : TableBase<EntityMOverrideHitEffectConditionDamageAttribute>
    {
        private readonly Func<EntityMOverrideHitEffectConditionDamageAttribute, int> primaryIndexSelector;

        public EntityMOverrideHitEffectConditionDamageAttributeTable(EntityMOverrideHitEffectConditionDamageAttribute[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.OverrideHitEffectConditionId;
        }
        
        public EntityMOverrideHitEffectConditionDamageAttribute FindByOverrideHitEffectConditionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
