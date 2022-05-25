using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMWeaponSpecificEnhanceTable : TableBase<EntityMWeaponSpecificEnhance> // TypeDefIndex: 12437
    {
        // Fields
        private readonly Func<EntityMWeaponSpecificEnhance, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2BACF4C Offset: 0x2BACF4C VA: 0x2BACF4C
        public EntityMWeaponSpecificEnhanceTable(EntityMWeaponSpecificEnhance[] sortedData):base(sortedData)
        {
            primaryIndexSelector = enhance => enhance.WeaponSpecificEnhanceId;
        }

        // RVA: 0x2BAD04C Offset: 0x2BAD04C VA: 0x2BAD04C
        public EntityMWeaponSpecificEnhance FindByWeaponSpecificEnhanceId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
