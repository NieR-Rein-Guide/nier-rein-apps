using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActionAttackClampHpTable : TableBase<EntityMSkillBehaviourActionAttackClampHp>
    {
        private readonly Func<EntityMSkillBehaviourActionAttackClampHp, int> primaryIndexSelector;

        public EntityMSkillBehaviourActionAttackClampHpTable(EntityMSkillBehaviourActionAttackClampHp[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActionId;
        }

        public bool TryFindBySkillBehaviourActionId(int key, out EntityMSkillBehaviourActionAttackClampHp result) =>
            TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
    }
}
