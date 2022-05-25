using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMWeaponEnhancedTable : TableBase<EntityMWeaponEnhanced> // TypeDefIndex: 12487
    {
        // Fields
        private readonly Func<EntityMWeaponEnhanced, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2CDE940 Offset: 0x2CDE940 VA: 0x2CDE940
        public EntityMWeaponEnhancedTable(EntityMWeaponEnhanced[] sortedData):base(sortedData)
        {
            primaryIndexSelector = enhance => enhance.WeaponEnhancedId;
        }

        // RVA: 0x2CDEA40 Offset: 0x2CDEA40 VA: 0x2CDEA40
        public bool TryFindByWeaponEnhancedId(int key, out EntityMWeaponEnhanced result)
        {
            result = null;

            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                {
                    result = element;
                    return true;
                }

            return false;
        }
    }
}
