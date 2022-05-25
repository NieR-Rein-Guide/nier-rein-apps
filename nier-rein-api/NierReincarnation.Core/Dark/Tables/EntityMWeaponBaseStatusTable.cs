using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMWeaponBaseStatusTable : TableBase<EntityMWeaponBaseStatus> // TypeDefIndex: 12415
    {
        // Fields
        private readonly Func<EntityMWeaponBaseStatus, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2BAB2E8 Offset: 0x2BAB2E8 VA: 0x2BAB2E8
        public EntityMWeaponBaseStatusTable(EntityMWeaponBaseStatus[] sortedData):base(sortedData)
        {
            primaryIndexSelector = status => status.WeaponBaseStatusId;
        }

        // RVA: 0x2BAB3E8 Offset: 0x2BAB3E8 VA: 0x2BAB3E8
        public EntityMWeaponBaseStatus FindByWeaponBaseStatusId(int key)
        {
            foreach(var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }
    }
}
