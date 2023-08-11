using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserNaviCutInTable : TableBase<EntityIUserNaviCutIn>
{
    private readonly Func<EntityIUserNaviCutIn, (long, int)> primaryIndexSelector;

    public EntityIUserNaviCutInTable(EntityIUserNaviCutIn[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.NaviCutInId);
    }

    public bool TryFindByUserIdAndNaviCutInId(ValueTuple<long, int> key, out EntityIUserNaviCutIn result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key, out result);
}
