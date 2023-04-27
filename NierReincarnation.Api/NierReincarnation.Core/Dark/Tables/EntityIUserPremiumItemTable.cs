using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserPremiumItemTable : TableBase<EntityIUserPremiumItem>
    {
        private readonly Func<EntityIUserPremiumItem, (long, int)> primaryIndexSelector;

        public EntityIUserPremiumItemTable(EntityIUserPremiumItem[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.PremiumItemId);
        }

        public EntityIUserPremiumItem FindByUserIdAndPremiumItemId(ValueTuple<long, int> key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key); }

        public bool TryFindByUserIdAndPremiumItemId(ValueTuple<long, int> key, out EntityIUserPremiumItem result)
        { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key, out result); }
    }
}
