using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMWeaponTable : TableBase<EntityMWeapon>
    {
        private readonly Func<EntityMWeapon, int> primaryIndexSelector;

        public EntityMWeaponTable(EntityMWeapon[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.WeaponId;
        }

        public EntityMWeapon FindByWeaponId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
