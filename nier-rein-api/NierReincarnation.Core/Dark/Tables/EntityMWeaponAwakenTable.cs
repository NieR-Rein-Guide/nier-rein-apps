using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMWeaponAwakenTable : TableBase<EntityMWeaponAwaken>
    {
        private readonly Func<EntityMWeaponAwaken, int> primaryIndexSelector;

        public EntityMWeaponAwakenTable(EntityMWeaponAwaken[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.WeaponId;
        }
        
        public EntityMWeaponAwaken FindByWeaponId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

	
        public bool TryFindByWeaponId(int key, out EntityMWeaponAwaken result) { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result); }

    }
}
