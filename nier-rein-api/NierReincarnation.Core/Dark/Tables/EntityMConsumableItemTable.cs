using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMConsumableItemTable : TableBase<EntityMConsumableItem> // TypeDefIndex: 11875
    {
        // Fields
        private readonly Func<EntityMConsumableItem, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2BAE440 Offset: 0x2BAE440 VA: 0x2BAE440
        public EntityMConsumableItemTable(EntityMConsumableItem[] sortedData):base(sortedData)
        {
            primaryIndexSelector = item => item.ConsumableItemId;
        }

        // RVA: 0x2BAE540 Offset: 0x2BAE540 VA: 0x2BAE540
        public EntityMConsumableItem FindByConsumableItemId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
