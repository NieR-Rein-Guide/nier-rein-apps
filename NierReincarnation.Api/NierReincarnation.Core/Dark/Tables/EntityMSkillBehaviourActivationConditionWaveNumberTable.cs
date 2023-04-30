using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActivationConditionWaveNumberTable : TableBase<EntityMSkillBehaviourActivationConditionWaveNumber>
    {
        private readonly Func<EntityMSkillBehaviourActivationConditionWaveNumber, int> primaryIndexSelector;

        public EntityMSkillBehaviourActivationConditionWaveNumberTable(EntityMSkillBehaviourActivationConditionWaveNumber[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActivationConditionId;
        }

        public EntityMSkillBehaviourActivationConditionWaveNumber FindBySkillBehaviourActivationConditionId(int key) =>
            FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
