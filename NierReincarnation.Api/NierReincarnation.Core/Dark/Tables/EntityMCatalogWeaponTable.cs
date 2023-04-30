using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCatalogWeaponTable : TableBase<EntityMCatalogWeapon>
    {
        private readonly Func<EntityMCatalogWeapon, int> primaryIndexSelector;

        public EntityMCatalogWeaponTable(EntityMCatalogWeapon[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.WeaponId;
        }
    }
}
