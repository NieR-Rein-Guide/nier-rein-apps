using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMCatalogCompanionTable : TableBase<EntityMCatalogCompanion> // TypeDefIndex: 11733
    {
        // Fields
        private readonly Func<EntityMCatalogCompanion, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C48F70 Offset: 0x2C48F70 VA: 0x2C48F70
        public EntityMCatalogCompanionTable(EntityMCatalogCompanion[] sortedData):base(sortedData)
        {
            primaryIndexSelector = companion => companion.CompanionId;
        }

        // CUSTOM: Access to data via companion id
        public EntityMCatalogCompanion FindByCompanionId(int key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
