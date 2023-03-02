using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillAbnormalTable : TableBase<EntityMSkillAbnormal>
    {
        private readonly Func<EntityMSkillAbnormal, int> primaryIndexSelector;

        public EntityMSkillAbnormalTable(EntityMSkillAbnormal[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillAbnormalId;
        }
        
        public EntityMSkillAbnormal FindBySkillAbnormalId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
