using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActionSkillRecoveryPowerCorrectionTable : TableBase<EntityMSkillBehaviourActionSkillRecoveryPowerCorrection>
    {
        private readonly Func<EntityMSkillBehaviourActionSkillRecoveryPowerCorrection, int> primaryIndexSelector;

        public EntityMSkillBehaviourActionSkillRecoveryPowerCorrectionTable(EntityMSkillBehaviourActionSkillRecoveryPowerCorrection[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActionId;
        }
        
        public EntityMSkillBehaviourActionSkillRecoveryPowerCorrection FindBySkillBehaviourActionId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
