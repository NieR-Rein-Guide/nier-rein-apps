using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillAbnormalDamageMultiplyDetailCriticalTable : TableBase<EntityMSkillAbnormalDamageMultiplyDetailCritical>
    {
        private readonly Func<EntityMSkillAbnormalDamageMultiplyDetailCritical, int> primaryIndexSelector;

        public EntityMSkillAbnormalDamageMultiplyDetailCriticalTable(EntityMSkillAbnormalDamageMultiplyDetailCritical[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.DamageMultiplyAbnormalDetailId;
        }

        public bool TryFindByDamageMultiplyAbnormalDetailId(int key, out EntityMSkillAbnormalDamageMultiplyDetailCritical result) =>
            TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
    }
}
