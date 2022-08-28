using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMShopItemContentEffectTable : TableBase<EntityMShopItemContentEffect>
    {
        private readonly Func<EntityMShopItemContentEffect, int> primaryIndexSelector;

        public EntityMShopItemContentEffectTable(EntityMShopItemContentEffect[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => element.ShopItemId;
        }
        
        public EntityMShopItemContentEffect FindByShopItemId(int key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key); }

    }
}
