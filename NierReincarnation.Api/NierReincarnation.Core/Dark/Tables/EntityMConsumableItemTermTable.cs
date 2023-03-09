using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMConsumableItemTermTable : TableBase<EntityMConsumableItemTerm> // TypeDefIndex: 11825
    {
        // Fields
        private readonly Func<EntityMConsumableItemTerm, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B3EBC4 Offset: 0x2B3EBC4 VA: 0x2B3EBC4
        public EntityMConsumableItemTermTable(EntityMConsumableItemTerm[] sortedData):base(sortedData)
        {
            primaryIndexSelector = term => term.ConsumableItemTermId;
        }

        // RVA: 0x2B3ECC4 Offset: 0x2B3ECC4 VA: 0x2B3ECC4
        public EntityMConsumableItemTerm FindByConsumableItemTermId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
