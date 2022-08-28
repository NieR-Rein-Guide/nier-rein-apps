using System;
using System.Collections.Generic;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityMPlatformPaymentPriceTable : TableBase<EntityMPlatformPaymentPrice>
    {
        private readonly Func<EntityMPlatformPaymentPrice, (int,int)> primaryIndexSelector;

        public EntityMPlatformPaymentPriceTable(EntityMPlatformPaymentPrice[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.PlatformPaymentId,element.PlatformType);
        }
        
        public EntityMPlatformPaymentPrice FindByPlatformPaymentIdAndPlatformType(ValueTuple<int, int> key) { return FindUniqueCore(data, primaryIndexSelector, Comparer<(int,int)>.Default, key); }

    }
}
