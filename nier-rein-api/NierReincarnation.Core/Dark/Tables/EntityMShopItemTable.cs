using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMShopItemTable : TableBase<EntityMShopItem> // TypeDefIndex: 12207
    {
        // Fields
        private readonly Func<EntityMShopItem, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C58E04 Offset: 0x2C58E04 VA: 0x2C58E04
        public EntityMShopItemTable(EntityMShopItem[] sortedData):base(sortedData)
        {
            primaryIndexSelector = item => item.ShopItemId;
        }

        // RVA: 0x2C58F04 Offset: 0x2C58F04 VA: 0x2C58F04
        public EntityMShopItem FindByShopItemId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
