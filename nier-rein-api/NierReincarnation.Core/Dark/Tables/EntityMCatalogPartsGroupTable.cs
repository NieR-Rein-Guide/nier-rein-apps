using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMCatalogPartsGroupTable : TableBase<EntityMCatalogPartsGroup> // TypeDefIndex: 11737
    {
        // Fields
        private readonly Func<EntityMCatalogPartsGroup, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C49320 Offset: 0x2C49320 VA: 0x2C49320
        public EntityMCatalogPartsGroupTable(EntityMCatalogPartsGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => group.PartsGroupId;
        }

        // CUSTOM: Access to data via parts id
        public EntityMCatalogPartsGroup FindByPartsGroupId(int key)
        {
            foreach (var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
