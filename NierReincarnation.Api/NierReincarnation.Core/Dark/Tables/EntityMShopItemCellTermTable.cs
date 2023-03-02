using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMShopItemCellTermTable : TableBase<EntityMShopItemCellTerm> // TypeDefIndex: 12197
    {
        // Fields
        private readonly Func<EntityMShopItemCellTerm, int> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C583BC Offset: 0x2C583BC VA: 0x2C583BC
        public EntityMShopItemCellTermTable(EntityMShopItemCellTerm[] sortedData):base(sortedData)
        {
            primaryIndexSelector = term => term.ShopItemCellTermId;
        }

        // RVA: 0x2C584BC Offset: 0x2C584BC VA: 0x2C584BC
        public EntityMShopItemCellTerm FindByShopItemCellTermId(int key)
        {
            foreach(var element in data)
                if (primaryIndexSelector(element) == key)
                    return element;

            return null;
        }
    }
}
