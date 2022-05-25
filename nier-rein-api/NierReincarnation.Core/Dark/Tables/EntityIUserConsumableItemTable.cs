using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserConsumableItemTable : TableBase<EntityIUserConsumableItem> // TypeDefIndex: 12489
    {
        // Fields
        private readonly Func<EntityIUserConsumableItem, (long, int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2DC9770 Offset: 0x2DC9770 VA: 0x2DC9770
        public EntityIUserConsumableItemTable(EntityIUserConsumableItem[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = item => (item.UserId, item.ConsumableItemId);
        }

        public EntityIUserConsumableItem FindByUserIdAndConsumableItemId((long,int) key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
