using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActivationConditionHpRatioTable : TableBase<EntityMSkillBehaviourActivationConditionHpRatio>
    {
        private readonly Func<EntityMSkillBehaviourActivationConditionHpRatio, int> primaryIndexSelector;

        public EntityMSkillBehaviourActivationConditionHpRatioTable(EntityMSkillBehaviourActivationConditionHpRatio[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActivationConditionId;
        }
        
        public EntityMSkillBehaviourActivationConditionHpRatio FindBySkillBehaviourActivationConditionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
