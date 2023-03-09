using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActionActiveSkillDamageCorrectionTable : TableBase<EntityMSkillBehaviourActionActiveSkillDamageCorrection>
    {
        private readonly Func<EntityMSkillBehaviourActionActiveSkillDamageCorrection, int> primaryIndexSelector;

        public EntityMSkillBehaviourActionActiveSkillDamageCorrectionTable(EntityMSkillBehaviourActionActiveSkillDamageCorrection[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActionId;
        }
        
        public EntityMSkillBehaviourActionActiveSkillDamageCorrection FindBySkillBehaviourActionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
