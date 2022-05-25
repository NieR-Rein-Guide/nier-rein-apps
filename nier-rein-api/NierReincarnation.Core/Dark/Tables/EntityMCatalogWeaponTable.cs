using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCatalogWeaponTable : TableBase<EntityMCatalogWeapon> // TypeDefIndex: 11741
    {
        // Fields
        private readonly Func<EntityMCatalogWeapon, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C496BC Offset: 0x2C496BC VA: 0x2C496BC
        public EntityMCatalogWeaponTable(EntityMCatalogWeapon[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = weapon => weapon.WeaponId;
        }

        // CUSTOM: Access to data via weapon id
        public EntityMCatalogWeapon FindByWeaponId(int key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
