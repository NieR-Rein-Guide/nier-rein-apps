using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMShopItemCellLimitedOpenTable : TableBase<EntityMShopItemCellLimitedOpen>
{
    private readonly Func<EntityMShopItemCellLimitedOpen, int> primaryIndexSelector;

    public EntityMShopItemCellLimitedOpenTable(EntityMShopItemCellLimitedOpen[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.ShopItemCellId;
    }

    public EntityMShopItemCellLimitedOpen FindByShopItemCellId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
