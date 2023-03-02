using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMCompanionEnhancedTable : TableBase<EntityMCompanionEnhanced> // TypeDefIndex: 11859
    {
        // Fields
        private readonly Func<EntityMCompanionEnhanced, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2BAD2F4 Offset: 0x2BAD2F4 VA: 0x2BAD2F4
        public EntityMCompanionEnhancedTable(EntityMCompanionEnhanced[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = enhance => enhance.CompanionEnhancedId;
        }

        // RVA: 0x2BAD3F4 Offset: 0x2BAD3F4 VA: 0x2BAD3F4
        public bool TryFindByCompanionEnhancedId(int key, out EntityMCompanionEnhanced result)
        {
            result = null;

            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                {
                    result = element;
                    return true;
                }

            return false;
        }
    }
}
