using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCostumeAwakenAbilityTable : TableBase<EntityMCostumeAwakenAbility>
    {
        private readonly Func<EntityMCostumeAwakenAbility, int> primaryIndexSelector;

        public EntityMCostumeAwakenAbilityTable(EntityMCostumeAwakenAbility[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.CostumeAwakenAbilityId;
        }
        
        public EntityMCostumeAwakenAbility FindByCostumeAwakenAbilityId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

	
        public bool TryFindByCostumeAwakenAbilityId(int key, out EntityMCostumeAwakenAbility result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
