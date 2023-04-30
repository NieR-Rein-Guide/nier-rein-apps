using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMShopItemCellTable : TableBase<EntityMShopItemCell>
    {
        private readonly Func<EntityMShopItemCell, (int, int)> primaryIndexSelector;

        public EntityMShopItemCellTable(EntityMShopItemCell[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.ShopItemCellId, element.StepNumber);
        }
    }
}
