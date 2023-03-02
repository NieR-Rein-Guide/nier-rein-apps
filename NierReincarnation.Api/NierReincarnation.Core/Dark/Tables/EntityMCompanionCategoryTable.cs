using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMCompanionCategoryTable : TableBase<EntityMCompanionCategory> // TypeDefIndex: 11803
    {
        // Fields
        private readonly Func<EntityMCompanionCategory, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B40B18 Offset: 0x2B40B18 VA: 0x2B40B18
        public EntityMCompanionCategoryTable(EntityMCompanionCategory[] sortedData):base(sortedData)
        {
            primaryIndexSelector = category => category.CompanionCategoryType;
        }

        // RVA: 0x2B40C18 Offset: 0x2B40C18 VA: 0x2B40C18
        public EntityMCompanionCategory FindByCompanionCategoryType(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
