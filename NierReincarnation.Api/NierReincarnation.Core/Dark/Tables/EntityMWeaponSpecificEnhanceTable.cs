using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMWeaponSpecificEnhanceTable : TableBase<EntityMWeaponSpecificEnhance>
    {
        private readonly Func<EntityMWeaponSpecificEnhance, int> primaryIndexSelector;

        public EntityMWeaponSpecificEnhanceTable(EntityMWeaponSpecificEnhance[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.WeaponSpecificEnhanceId;
        }

        public EntityMWeaponSpecificEnhance FindByWeaponSpecificEnhanceId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
