using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserOmikujiTable : TableBase<EntityIUserOmikuji>
    {
        private readonly Func<EntityIUserOmikuji, (long, int)> primaryIndexSelector;

        public EntityIUserOmikujiTable(EntityIUserOmikuji[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.OmikujiId);
        }

        public EntityIUserOmikuji FindByUserIdAndOmikujiId(ValueTuple<long, int> key)
        { return FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key); }
    }
}
