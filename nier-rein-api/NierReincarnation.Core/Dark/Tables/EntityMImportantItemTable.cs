using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMImportantItemTable : TableBase<EntityMImportantItem> // TypeDefIndex: 11967
    {
        // Fields
        private readonly Func<EntityMImportantItem, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B48670 Offset: 0x2B48670 VA: 0x2B48670
        public EntityMImportantItemTable(EntityMImportantItem[] sortedData):base(sortedData)
        {
            primaryIndexSelector = item => item.ImportantItemId;
        }

        // RVA: 0x2B48770 Offset: 0x2B48770 VA: 0x2B48770
        public EntityMImportantItem FindByImportantItemId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
