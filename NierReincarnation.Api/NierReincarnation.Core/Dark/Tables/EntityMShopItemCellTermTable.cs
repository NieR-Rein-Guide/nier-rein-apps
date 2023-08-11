using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMShopItemCellTermTable : TableBase<EntityMShopItemCellTerm>
{
    private readonly Func<EntityMShopItemCellTerm, int> primaryIndexSelector;

    public EntityMShopItemCellTermTable(EntityMShopItemCellTerm[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.ShopItemCellTermId;
    }

    public EntityMShopItemCellTerm FindByShopItemCellTermId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
