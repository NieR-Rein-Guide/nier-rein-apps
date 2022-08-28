using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActionBuffTable : TableBase<EntityMSkillBehaviourActionBuff>
    {
        private readonly Func<EntityMSkillBehaviourActionBuff, int> primaryIndexSelector;

        public EntityMSkillBehaviourActionBuffTable(EntityMSkillBehaviourActionBuff[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActionId;
        }
        
        public EntityMSkillBehaviourActionBuff FindBySkillBehaviourActionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
