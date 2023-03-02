using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillAbnormalDamageMultiplyDetailHitIndexTable : TableBase<EntityMSkillAbnormalDamageMultiplyDetailHitIndex>
    {
        private readonly Func<EntityMSkillAbnormalDamageMultiplyDetailHitIndex, int> primaryIndexSelector;

        public EntityMSkillAbnormalDamageMultiplyDetailHitIndexTable(EntityMSkillAbnormalDamageMultiplyDetailHitIndex[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.DamageMultiplyAbnormalDetailId;
        }
        
        public EntityMSkillAbnormalDamageMultiplyDetailHitIndex FindByDamageMultiplyAbnormalDetailId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
