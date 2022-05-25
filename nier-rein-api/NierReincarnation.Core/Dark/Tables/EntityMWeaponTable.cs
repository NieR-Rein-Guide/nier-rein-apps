using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMWeaponTable : TableBase<EntityMWeapon> // TypeDefIndex: 12449
    {
        private readonly Func<EntityMWeapon, int> primaryIndexSelector; // 0x18

        public EntityMWeaponTable(EntityMWeapon[] sortedData):base(sortedData)
        {
            primaryIndexSelector = weapon => weapon.WeaponId;
        }

        public EntityMWeapon FindByWeaponId(int key)
        {
            foreach(var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }
    }
}
