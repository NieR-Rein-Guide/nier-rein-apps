using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillDamageMultiplyDetailBuffAttachedTable : TableBase<EntityMSkillDamageMultiplyDetailBuffAttached>
    {
        private readonly Func<EntityMSkillDamageMultiplyDetailBuffAttached, int> primaryIndexSelector;

        public EntityMSkillDamageMultiplyDetailBuffAttachedTable(EntityMSkillDamageMultiplyDetailBuffAttached[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillDamageMultiplyDetailId;
        }
        
        public bool TryFindBySkillDamageMultiplyDetailId(int key, out EntityMSkillDamageMultiplyDetailBuffAttached result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
