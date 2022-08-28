using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillCooltimeBehaviourTable : TableBase<EntityMSkillCooltimeBehaviour>
    {
        private readonly Func<EntityMSkillCooltimeBehaviour, int> primaryIndexSelector;

        public EntityMSkillCooltimeBehaviourTable(EntityMSkillCooltimeBehaviour[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillCooltimeBehaviourId;
        }
        
        public EntityMSkillCooltimeBehaviour FindBySkillCooltimeBehaviourId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
