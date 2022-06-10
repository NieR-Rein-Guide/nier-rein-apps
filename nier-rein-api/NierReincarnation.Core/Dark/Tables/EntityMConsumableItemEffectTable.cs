using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMConsumableItemEffectTable : TableBase<EntityMConsumableItemEffect> // TypeDefIndex: 11821
    {
        // Fields
        private readonly Func<EntityMConsumableItemEffect, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2B3E794 Offset: 0x2B3E794 VA: 0x2B3E794
        public EntityMConsumableItemEffectTable(EntityMConsumableItemEffect[] sortedData):base(sortedData)
        {
            primaryIndexSelector = effect => effect.ConsumableItemId;
        }

        // RVA: 0x2B3E894 Offset: 0x2B3E894 VA: 0x2B3E894
        public EntityMConsumableItemEffect FindByConsumableItemId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
