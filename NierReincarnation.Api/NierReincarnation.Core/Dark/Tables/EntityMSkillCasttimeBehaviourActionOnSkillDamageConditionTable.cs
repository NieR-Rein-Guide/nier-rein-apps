using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillCasttimeBehaviourActionOnSkillDamageConditionTable : TableBase<EntityMSkillCasttimeBehaviourActionOnSkillDamageCondition>
    {
        private readonly Func<EntityMSkillCasttimeBehaviourActionOnSkillDamageCondition, int> primaryIndexSelector;

        public EntityMSkillCasttimeBehaviourActionOnSkillDamageConditionTable(EntityMSkillCasttimeBehaviourActionOnSkillDamageCondition[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillCasttimeBehaviourActionId;
        }

        public bool TryFindBySkillCasttimeBehaviourActionId(int key, out EntityMSkillCasttimeBehaviourActionOnSkillDamageCondition result) =>
            TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
    }
}
