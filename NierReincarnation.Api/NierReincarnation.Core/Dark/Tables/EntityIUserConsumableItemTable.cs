using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserConsumableItemTable : TableBase<EntityIUserConsumableItem>
{
    private readonly Func<EntityIUserConsumableItem, (long, int)> primaryIndexSelector;

    public EntityIUserConsumableItemTable(EntityIUserConsumableItem[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.ConsumableItemId);
    }

    public bool TryFindByUserIdAndConsumableItemId(ValueTuple<long, int> key, out EntityIUserConsumableItem result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key, out result);
}
