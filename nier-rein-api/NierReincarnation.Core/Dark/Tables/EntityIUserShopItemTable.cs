using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityIUserShopItemTable : TableBase<EntityIUserShopItem> // TypeDefIndex: 12593
    {
        // Fields
        private readonly Func<EntityIUserShopItem, (long, int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x35BD6A4 Offset: 0x35BD6A4 VA: 0x35BD6A4
        public EntityIUserShopItemTable(EntityIUserShopItem[] sortedData):base(sortedData)
        {
            primaryIndexSelector = item => (item.UserId, item.ShopItemId);
        }

        public EntityIUserShopItem FindByUserIdAndShopItemId((long,int) key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
