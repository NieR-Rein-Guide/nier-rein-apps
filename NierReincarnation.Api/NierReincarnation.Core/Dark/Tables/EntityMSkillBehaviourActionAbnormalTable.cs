using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActionAbnormalTable : TableBase<EntityMSkillBehaviourActionAbnormal>
    {
        private readonly Func<EntityMSkillBehaviourActionAbnormal, int> primaryIndexSelector;

        public EntityMSkillBehaviourActionAbnormalTable(EntityMSkillBehaviourActionAbnormal[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActionId;
        }
        
        public EntityMSkillBehaviourActionAbnormal FindBySkillBehaviourActionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
