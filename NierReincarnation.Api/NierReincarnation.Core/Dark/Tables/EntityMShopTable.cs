using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMShopTable : TableBase<EntityMShop>
{
    private readonly Func<EntityMShop, int> primaryIndexSelector;

    public EntityMShopTable(EntityMShop[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.ShopId;
    }

    public EntityMShop FindByShopId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);

    public bool TryFindByShopId(int key, out EntityMShop result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
