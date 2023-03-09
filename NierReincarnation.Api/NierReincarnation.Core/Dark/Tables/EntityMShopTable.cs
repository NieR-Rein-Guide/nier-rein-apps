using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMShopTable : TableBase<EntityMShop> // TypeDefIndex: 12213
    {
        // Fields
        private readonly Func<EntityMShop, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C59324 Offset: 0x2C59324 VA: 0x2C59324
        public EntityMShopTable(EntityMShop[] sortedData):base(sortedData)
        {
            primaryIndexSelector = shop => shop.ShopId;
        }

        // RVA: 0x2C59424 Offset: 0x2C59424 VA: 0x2C59424
        public EntityMShop FindByShopId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
