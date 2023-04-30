using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMShopItemCellGroupTable : TableBase<EntityMShopItemCellGroup>
    {
        private readonly Func<EntityMShopItemCellGroup, (int, int)> primaryIndexSelector;

        public EntityMShopItemCellGroupTable(EntityMShopItemCellGroup[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.ShopItemCellGroupId, element.ShopItemCellId);
        }
    }
}
