using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMShopItemCellGroupTable : TableBase<EntityMShopItemCellGroup> // TypeDefIndex: 12193
    {
        // Fields
        private readonly Func<EntityMShopItemCellGroup, (int, int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C58004 Offset: 0x2C58004 VA: 0x2C58004
        public EntityMShopItemCellGroupTable(EntityMShopItemCellGroup[] sortedData):base(sortedData)
        {
            primaryIndexSelector = group => (group.ShopItemCellGroupId, group.ShopItemCellId);
        }
    }
}
