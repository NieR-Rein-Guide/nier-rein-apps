using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMSkillReserveUiTypeTable : TableBase<EntityMSkillReserveUiType>
    {
        private readonly Func<EntityMSkillReserveUiType, int> primaryIndexSelector;

        public EntityMSkillReserveUiTypeTable(EntityMSkillReserveUiType[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.SkillDetailId;
        }
        
        public bool TryFindBySkillDetailId(int key, out EntityMSkillReserveUiType result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
