using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillCooltimeBehaviourOnExecuteDefaultSkillTable : TableBase<EntityMSkillCooltimeBehaviourOnExecuteDefaultSkill>
    {
        private readonly Func<EntityMSkillCooltimeBehaviourOnExecuteDefaultSkill, int> primaryIndexSelector;

        public EntityMSkillCooltimeBehaviourOnExecuteDefaultSkillTable(EntityMSkillCooltimeBehaviourOnExecuteDefaultSkill[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillCooltimeBehaviourActionId;
        }
        
        public bool TryFindBySkillCooltimeBehaviourActionId(int key, out EntityMSkillCooltimeBehaviourOnExecuteDefaultSkill result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
