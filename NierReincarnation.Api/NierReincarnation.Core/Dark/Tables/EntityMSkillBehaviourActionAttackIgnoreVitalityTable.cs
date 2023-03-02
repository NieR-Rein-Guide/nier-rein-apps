using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActionAttackIgnoreVitalityTable : TableBase<EntityMSkillBehaviourActionAttackIgnoreVitality>
    {
        private readonly Func<EntityMSkillBehaviourActionAttackIgnoreVitality, int> primaryIndexSelector;

        public EntityMSkillBehaviourActionAttackIgnoreVitalityTable(EntityMSkillBehaviourActionAttackIgnoreVitality[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActionId;
        }
        
        public EntityMSkillBehaviourActionAttackIgnoreVitality FindBySkillBehaviourActionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
