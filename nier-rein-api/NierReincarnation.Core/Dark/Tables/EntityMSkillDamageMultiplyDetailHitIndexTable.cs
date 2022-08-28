using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillDamageMultiplyDetailHitIndexTable : TableBase<EntityMSkillDamageMultiplyDetailHitIndex>
    {
        private readonly Func<EntityMSkillDamageMultiplyDetailHitIndex, int> primaryIndexSelector;

        public EntityMSkillDamageMultiplyDetailHitIndexTable(EntityMSkillDamageMultiplyDetailHitIndex[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillDamageMultiplyDetailId;
        }
        
        public EntityMSkillDamageMultiplyDetailHitIndex FindBySkillDamageMultiplyDetailId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
