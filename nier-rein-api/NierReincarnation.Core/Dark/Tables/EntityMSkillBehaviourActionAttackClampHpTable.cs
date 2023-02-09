using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActionAttackClampHpTable : TableBase<EntityMSkillBehaviourActionAttackClampHp>
    {
        private readonly Func<EntityMSkillBehaviourActionAttackClampHp, int> primaryIndexSelector;

        public EntityMSkillBehaviourActionAttackClampHpTable(EntityMSkillBehaviourActionAttackClampHp[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActionId;
        }
        
        public bool TryFindBySkillBehaviourActionId(int key, out EntityMSkillBehaviourActionAttackClampHp result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
