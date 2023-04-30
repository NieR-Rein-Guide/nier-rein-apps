using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActivationConditionAttributeTable : TableBase<EntityMSkillBehaviourActivationConditionAttribute>
    {
        private readonly Func<EntityMSkillBehaviourActivationConditionAttribute, int> primaryIndexSelector;

        public EntityMSkillBehaviourActivationConditionAttributeTable(EntityMSkillBehaviourActivationConditionAttribute[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActivationConditionId;
        }

        public EntityMSkillBehaviourActivationConditionAttribute FindBySkillBehaviourActivationConditionId(int key) =>
            FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
