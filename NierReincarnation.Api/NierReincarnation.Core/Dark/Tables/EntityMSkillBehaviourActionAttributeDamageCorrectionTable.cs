using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActionAttributeDamageCorrectionTable : TableBase<EntityMSkillBehaviourActionAttributeDamageCorrection>
    {
        private readonly Func<EntityMSkillBehaviourActionAttributeDamageCorrection, int> primaryIndexSelector;

        public EntityMSkillBehaviourActionAttributeDamageCorrectionTable(EntityMSkillBehaviourActionAttributeDamageCorrection[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActionId;
        }

        public EntityMSkillBehaviourActionAttributeDamageCorrection FindBySkillBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
