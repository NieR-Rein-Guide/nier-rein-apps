using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMCompanionStatusCalculationTable : TableBase<EntityMCompanionStatusCalculation> // TypeDefIndex: 11813
    {
        // Fields
        private readonly Func<EntityMCompanionStatusCalculation, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B415C8 Offset: 0x2B415C8 VA: 0x2B415C8
        public EntityMCompanionStatusCalculationTable(EntityMCompanionStatusCalculation[] sortedData):base(sortedData)
        {
            primaryIndexSelector = calculation => calculation.CompanionStatusCalculationId;
        }

        // RVA: 0x2B416C8 Offset: 0x2B416C8 VA: 0x2B416C8
        public EntityMCompanionStatusCalculation FindByCompanionStatusCalculationId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
