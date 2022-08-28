using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillAbnormalBehaviourTable : TableBase<EntityMSkillAbnormalBehaviour>
    {
        private readonly Func<EntityMSkillAbnormalBehaviour, int> primaryIndexSelector;

        public EntityMSkillAbnormalBehaviourTable(EntityMSkillAbnormalBehaviour[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillAbnormalBehaviourId;
        }
        
        public EntityMSkillAbnormalBehaviour FindBySkillAbnormalBehaviourId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
