using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMCatalogTermTable : TableBase<EntityMCatalogTerm> // TypeDefIndex: 11739
    {
        // Fields
        private readonly Func<EntityMCatalogTerm, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C494A4 Offset: 0x2C494A4 VA: 0x2C494A4
        public EntityMCatalogTermTable(EntityMCatalogTerm[] sortedData):base(sortedData)
        {
            primaryIndexSelector = term => term.CatalogTermId;
        }

        // RVA: 0x2C495A4 Offset: 0x2C495A4 VA: 0x2C495A4
        public EntityMCatalogTerm FindByCatalogTermId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
