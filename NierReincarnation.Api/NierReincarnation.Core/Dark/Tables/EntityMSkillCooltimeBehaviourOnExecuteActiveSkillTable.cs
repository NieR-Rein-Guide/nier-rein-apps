using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillCooltimeBehaviourOnExecuteActiveSkillTable : TableBase<EntityMSkillCooltimeBehaviourOnExecuteActiveSkill>
    {
        private readonly Func<EntityMSkillCooltimeBehaviourOnExecuteActiveSkill, int> primaryIndexSelector;

        public EntityMSkillCooltimeBehaviourOnExecuteActiveSkillTable(EntityMSkillCooltimeBehaviourOnExecuteActiveSkill[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillCooltimeBehaviourActionId;
        }
        
        public bool TryFindBySkillCooltimeBehaviourActionId(int key, out EntityMSkillCooltimeBehaviourOnExecuteActiveSkill result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
