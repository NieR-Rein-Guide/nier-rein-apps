using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMWeaponAwakenAbilityTable : TableBase<EntityMWeaponAwakenAbility>
    {
        private readonly Func<EntityMWeaponAwakenAbility, int> primaryIndexSelector;

        public EntityMWeaponAwakenAbilityTable(EntityMWeaponAwakenAbility[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.WeaponAwakenAbilityId;
        }
        
        public EntityMWeaponAwakenAbility FindByWeaponAwakenAbilityId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
