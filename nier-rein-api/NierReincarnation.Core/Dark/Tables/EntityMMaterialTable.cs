using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMMaterialTable : TableBase<EntityMMaterial> // TypeDefIndex: 12061
    {
        // Fields
        private readonly Func<EntityMMaterial, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C227F0 Offset: 0x2C227F0 VA: 0x2C227F0
        public EntityMMaterialTable(EntityMMaterial[] sortedData):base(sortedData)
        {
            primaryIndexSelector = material => material.MaterialId;
        }

        // RVA: 0x2C228F0 Offset: 0x2C228F0 VA: 0x2C228F0
        public EntityMMaterial FindByMaterialId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
