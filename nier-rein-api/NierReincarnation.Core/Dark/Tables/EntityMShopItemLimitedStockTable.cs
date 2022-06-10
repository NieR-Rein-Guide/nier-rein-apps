using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMShopItemLimitedStockTable : TableBase<EntityMShopItemLimitedStock> // TypeDefIndex: 12205
    {
        // Fields
        private readonly Func<EntityMShopItemLimitedStock, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C58BEC Offset: 0x2C58BEC VA: 0x2C58BEC
        public EntityMShopItemLimitedStockTable(EntityMShopItemLimitedStock[] sortedData):base(sortedData)
        {
            primaryIndexSelector = stock => stock.ShopItemLimitedStockId;
        }

        // RVA: 0x2C58CEC Offset: 0x2C58CEC VA: 0x2C58CEC
        public EntityMShopItemLimitedStock FindByShopItemLimitedStockId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
