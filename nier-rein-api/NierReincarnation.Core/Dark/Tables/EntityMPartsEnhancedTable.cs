using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMPartsEnhancedTable : TableBase<EntityMPartsEnhanced> // TypeDefIndex: 12103
    {
        // Fields
        private readonly Func<EntityMPartsEnhanced, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C253BC Offset: 0x2C253BC VA: 0x2C253BC
        public EntityMPartsEnhancedTable(EntityMPartsEnhanced[] sortedData):base(sortedData)
        {
            primaryIndexSelector = enhance => enhance.PartsEnhancedId;
        }

        // RVA: 0x2C254BC Offset: 0x2C254BC VA: 0x2C254BC
        public bool TryFindByPartsEnhancedId(int key, out EntityMPartsEnhanced result)
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
