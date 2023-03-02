using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMCostumeStatusCalculationTable : TableBase<EntityMCostumeStatusCalculation> // TypeDefIndex: 11869
    {
        // Fields
        private readonly Func<EntityMCostumeStatusCalculation, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B4548C Offset: 0x2B4548C VA: 0x2B4548C
        public EntityMCostumeStatusCalculationTable(EntityMCostumeStatusCalculation[] sortedData):base(sortedData)
        {
            primaryIndexSelector = calculation => calculation.CostumeStatusCalculationId;
        }

        // RVA: 0x2B4558C Offset: 0x2B4558C VA: 0x2B4558C
        public EntityMCostumeStatusCalculation FindByCostumeStatusCalculationId(int key)
        {
            foreach(var entry in data)
                if (primaryIndexSelector(entry) == key)
                    return entry;

            return null;
        }
    }
}
