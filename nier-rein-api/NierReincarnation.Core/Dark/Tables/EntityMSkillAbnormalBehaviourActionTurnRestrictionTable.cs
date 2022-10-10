using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillAbnormalBehaviourActionTurnRestrictionTable : TableBase<EntityMSkillAbnormalBehaviourActionTurnRestriction>
    {
        private readonly Func<EntityMSkillAbnormalBehaviourActionTurnRestriction, int> primaryIndexSelector;

        public EntityMSkillAbnormalBehaviourActionTurnRestrictionTable(EntityMSkillAbnormalBehaviourActionTurnRestriction[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActionId;
        }
        
        public EntityMSkillAbnormalBehaviourActionTurnRestriction FindBySkillBehaviourActionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}