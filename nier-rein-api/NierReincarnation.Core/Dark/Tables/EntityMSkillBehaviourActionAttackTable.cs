using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActionAttackTable : TableBase<EntityMSkillBehaviourActionAttack>
    {
        private readonly Func<EntityMSkillBehaviourActionAttack, int> primaryIndexSelector;

        public EntityMSkillBehaviourActionAttackTable(EntityMSkillBehaviourActionAttack[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActionId;
        }
        
        public EntityMSkillBehaviourActionAttack FindBySkillBehaviourActionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
