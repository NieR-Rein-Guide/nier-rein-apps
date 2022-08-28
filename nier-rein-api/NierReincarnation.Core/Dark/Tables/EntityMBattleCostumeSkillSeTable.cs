using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMBattleCostumeSkillSeTable : TableBase<EntityMBattleCostumeSkillSe>
    {
        private readonly Func<EntityMBattleCostumeSkillSe, int> primaryIndexSelector;

        public EntityMBattleCostumeSkillSeTable(EntityMBattleCostumeSkillSe[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.CostumeId;
        }
        
        public bool TryFindByCostumeId(int key, out EntityMBattleCostumeSkillSe result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
