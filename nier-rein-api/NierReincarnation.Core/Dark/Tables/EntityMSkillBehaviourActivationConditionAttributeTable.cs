using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActivationConditionAttributeTable : TableBase<EntityMSkillBehaviourActivationConditionAttribute>
    {
        private readonly Func<EntityMSkillBehaviourActivationConditionAttribute, int> primaryIndexSelector;

        public EntityMSkillBehaviourActivationConditionAttributeTable(EntityMSkillBehaviourActivationConditionAttribute[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActivationConditionId;
        }
        
        public EntityMSkillBehaviourActivationConditionAttribute FindBySkillBehaviourActivationConditionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
