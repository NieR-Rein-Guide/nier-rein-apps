using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillDamageMultiplyDetailSkillfulWeaponTypeTable : TableBase<EntityMSkillDamageMultiplyDetailSkillfulWeaponType>
    {
        private readonly Func<EntityMSkillDamageMultiplyDetailSkillfulWeaponType, int> primaryIndexSelector;

        public EntityMSkillDamageMultiplyDetailSkillfulWeaponTypeTable(EntityMSkillDamageMultiplyDetailSkillfulWeaponType[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillDamageMultiplyDetailId;
        }
        
        public bool TryFindBySkillDamageMultiplyDetailId(int key, out EntityMSkillDamageMultiplyDetailSkillfulWeaponType result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
