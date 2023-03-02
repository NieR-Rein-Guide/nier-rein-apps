using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActionRecoveryTable : TableBase<EntityMSkillBehaviourActionRecovery>
    {
        private readonly Func<EntityMSkillBehaviourActionRecovery, int> primaryIndexSelector;

        public EntityMSkillBehaviourActionRecoveryTable(EntityMSkillBehaviourActionRecovery[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActionId;
        }
        
        public EntityMSkillBehaviourActionRecovery FindBySkillBehaviourActionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
