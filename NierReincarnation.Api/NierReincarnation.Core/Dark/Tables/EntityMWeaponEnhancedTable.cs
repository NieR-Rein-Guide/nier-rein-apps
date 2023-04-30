using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMWeaponEnhancedTable : TableBase<EntityMWeaponEnhanced>
    {
        private readonly Func<EntityMWeaponEnhanced, int> primaryIndexSelector;

        public EntityMWeaponEnhancedTable(EntityMWeaponEnhanced[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.WeaponEnhancedId;
        }

        public bool TryFindByWeaponEnhancedId(int key, out EntityMWeaponEnhanced result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
    }
}
