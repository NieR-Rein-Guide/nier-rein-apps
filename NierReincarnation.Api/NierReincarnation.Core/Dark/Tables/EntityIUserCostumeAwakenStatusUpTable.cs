using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserCostumeAwakenStatusUpTable : TableBase<EntityIUserCostumeAwakenStatusUp>
{
    private readonly Func<EntityIUserCostumeAwakenStatusUp, (long, string, StatusCalculationType)> primaryIndexSelector;

    public EntityIUserCostumeAwakenStatusUpTable(EntityIUserCostumeAwakenStatusUp[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.UserCostumeUuid, element.StatusCalculationType);
    }

    public bool TryFindByUserIdAndUserCostumeUuidAndStatusCalculationType(ValueTuple<long, string, StatusCalculationType> key, out EntityIUserCostumeAwakenStatusUp result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, string, StatusCalculationType)>.Default, key, out result);
}
