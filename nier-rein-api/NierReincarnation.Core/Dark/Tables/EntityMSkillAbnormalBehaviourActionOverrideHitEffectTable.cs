using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillAbnormalBehaviourActionOverrideHitEffectTable : TableBase<EntityMSkillAbnormalBehaviourActionOverrideHitEffect>
    {
        private readonly Func<EntityMSkillAbnormalBehaviourActionOverrideHitEffect, int> primaryIndexSelector;

        public EntityMSkillAbnormalBehaviourActionOverrideHitEffectTable(EntityMSkillAbnormalBehaviourActionOverrideHitEffect[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillAbnormalBehaviourActionId;
        }
        
        public EntityMSkillAbnormalBehaviourActionOverrideHitEffect FindBySkillAbnormalBehaviourActionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
