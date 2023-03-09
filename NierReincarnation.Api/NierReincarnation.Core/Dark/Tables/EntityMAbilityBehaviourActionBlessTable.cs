using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMAbilityBehaviourActionBlessTable : TableBase<EntityMAbilityBehaviourActionBless>
    {
        private readonly Func<EntityMAbilityBehaviourActionBless, int> primaryIndexSelector;

        public EntityMAbilityBehaviourActionBlessTable(EntityMAbilityBehaviourActionBless[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.AbilityBehaviourActionId;
        }
        
        public EntityMAbilityBehaviourActionBless FindByAbilityBehaviourActionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
