using System;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
	public class EntityMShopItemCellTable : TableBase<EntityMShopItemCell> // TypeDefIndex: 12195
    {
        // Fields
        private readonly Func<EntityMShopItemCell, (int, int)> primaryIndexSelector; // 0x18

        // Methods

        // RVA: 0x2C581E0 Offset: 0x2C581E0 VA: 0x2C581E0
        public EntityMShopItemCellTable(EntityMShopItemCell[] sortedData):base(sortedData)
        {
            primaryIndexSelector = cell => (cell.ShopItemCellId, cell.StepNumber);
        }
    }
}
