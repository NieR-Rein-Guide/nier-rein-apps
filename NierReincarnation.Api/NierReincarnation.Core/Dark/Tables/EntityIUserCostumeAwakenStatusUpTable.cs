using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables
{
    public class EntityIUserCostumeAwakenStatusUpTable : TableBase<EntityIUserCostumeAwakenStatusUp>
    {
        private readonly Func<EntityIUserCostumeAwakenStatusUp, (long, string, int)> primaryIndexSelector;

        public EntityIUserCostumeAwakenStatusUpTable(EntityIUserCostumeAwakenStatusUp[] sortedData) : base(sortedData)
        {
            primaryIndexSelector = element => (element.UserId, element.UserCostumeUuid, element.StatusCalculationType);
        }

        public bool TryFindByUserIdAndUserCostumeUuidAndStatusCalculationType(ValueTuple<long, string, int> key, out EntityIUserCostumeAwakenStatusUp result)
        { return TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, string, int)>.Default, key, out result); }
    }
}
