using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillCasttimeBehaviourTable : TableBase<EntityMSkillCasttimeBehaviour>
    {
        private readonly Func<EntityMSkillCasttimeBehaviour, int> primaryIndexSelector;

        public EntityMSkillCasttimeBehaviourTable(EntityMSkillCasttimeBehaviour[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillCasttimeBehaviourId;
        }
        
        public EntityMSkillCasttimeBehaviour FindBySkillCasttimeBehaviourId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
