using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMShopDisplayPriceTable : TableBase<EntityMShopDisplayPrice>
    {
        private readonly Func<EntityMShopDisplayPrice, (int,int)> primaryIndexSelector;

        public EntityMShopDisplayPriceTable(EntityMShopDisplayPrice[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.PriceType,element.PriceId);
        }
        
        public EntityMShopDisplayPrice FindByPriceTypeAndPriceId(ValueTuple<int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key); }

    }
}
