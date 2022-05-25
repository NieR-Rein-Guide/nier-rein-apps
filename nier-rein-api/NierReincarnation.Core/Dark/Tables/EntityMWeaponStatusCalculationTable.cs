using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMWeaponStatusCalculationTable : TableBase<EntityMWeaponStatusCalculation> // TypeDefIndex: 12441
    {
        // Fields
        private readonly Func<EntityMWeaponStatusCalculation, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2BAD34C Offset: 0x2BAD34C VA: 0x2BAD34C
        public EntityMWeaponStatusCalculationTable(EntityMWeaponStatusCalculation[] sortedData):base(sortedData)
        {
            primaryIndexSelector = calculation => calculation.WeaponStatusCalculationId;
        }

        // RVA: 0x2BAD44C Offset: 0x2BAD44C VA: 0x2BAD44C
        public EntityMWeaponStatusCalculation FindByWeaponStatusCalculationId(int key)
        {
            foreach(var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }
    }
}
