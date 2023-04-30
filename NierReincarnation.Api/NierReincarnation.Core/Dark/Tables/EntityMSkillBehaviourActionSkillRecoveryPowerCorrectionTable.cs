using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActionSkillRecoveryPowerCorrectionTable : TableBase<EntityMSkillBehaviourActionSkillRecoveryPowerCorrection>
    {
        private readonly Func<EntityMSkillBehaviourActionSkillRecoveryPowerCorrection, int> primaryIndexSelector;

        public EntityMSkillBehaviourActionSkillRecoveryPowerCorrectionTable(EntityMSkillBehaviourActionSkillRecoveryPowerCorrection[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActionId;
        }

        public EntityMSkillBehaviourActionSkillRecoveryPowerCorrection FindBySkillBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
