using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeTable : TableBase<EntityMSkillBehaviourActionAdvanceActiveSkillCooltime>
    {
        private readonly Func<EntityMSkillBehaviourActionAdvanceActiveSkillCooltime, int> primaryIndexSelector;

        public EntityMSkillBehaviourActionAdvanceActiveSkillCooltimeTable(EntityMSkillBehaviourActionAdvanceActiveSkillCooltime[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActionId;
        }

        public EntityMSkillBehaviourActionAdvanceActiveSkillCooltime FindBySkillBehaviourActionId(int key) =>
            FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
