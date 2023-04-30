using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillAbnormalDamageMultiplyDetailSkillfulWeaponTable : TableBase<EntityMSkillAbnormalDamageMultiplyDetailSkillfulWeapon>
    {
        private readonly Func<EntityMSkillAbnormalDamageMultiplyDetailSkillfulWeapon, int> primaryIndexSelector;

        public EntityMSkillAbnormalDamageMultiplyDetailSkillfulWeaponTable(EntityMSkillAbnormalDamageMultiplyDetailSkillfulWeapon[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.DamageMultiplyAbnormalDetailId;
        }

        public bool TryFindByDamageMultiplyAbnormalDetailId(int key, out EntityMSkillAbnormalDamageMultiplyDetailSkillfulWeapon result) =>
            TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
    }
}
