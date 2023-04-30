using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillBehaviourActionAttackSkillfulMainWeaponTypeTable : TableBase<EntityMSkillBehaviourActionAttackSkillfulMainWeaponType>
    {
        private readonly Func<EntityMSkillBehaviourActionAttackSkillfulMainWeaponType, int> primaryIndexSelector;

        public EntityMSkillBehaviourActionAttackSkillfulMainWeaponTypeTable(EntityMSkillBehaviourActionAttackSkillfulMainWeaponType[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillBehaviourActionId;
        }

        public EntityMSkillBehaviourActionAttackSkillfulMainWeaponType FindBySkillBehaviourActionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
