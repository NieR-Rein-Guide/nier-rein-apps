using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMCostumeEnhancedTable : TableBase<EntityMCostumeEnhanced> // TypeDefIndex: 11907
    {
        // Fields
        private readonly Func<EntityMCostumeEnhanced, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2BB08D0 Offset: 0x2BB08D0 VA: 0x2BB08D0
        public EntityMCostumeEnhancedTable(EntityMCostumeEnhanced[] sortedData):base(sortedData)
        {
            primaryIndexSelector = enhance => enhance.CostumeEnhancedId;
        }

        // RVA: 0x2BB09D0 Offset: 0x2BB09D0 VA: 0x2BB09D0
        public bool TryFindByCostumeEnhancedId(int key, out EntityMCostumeEnhanced result)
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
