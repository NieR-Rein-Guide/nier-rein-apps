using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMShopItemTable : TableBase<EntityMShopItem>
    {
        private readonly Func<EntityMShopItem, int> primaryIndexSelector;

        public EntityMShopItemTable(EntityMShopItem[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.ShopItemId;
        }

        public EntityMShopItem FindByShopItemId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
    }
}
