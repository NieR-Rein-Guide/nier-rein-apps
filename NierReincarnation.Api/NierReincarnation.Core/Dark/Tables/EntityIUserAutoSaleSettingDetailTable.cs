using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserAutoSaleSettingDetailTable : TableBase<EntityIUserAutoSaleSettingDetail>
{
    private readonly Func<EntityIUserAutoSaleSettingDetail, (long, int)> primaryIndexSelector;

    public EntityIUserAutoSaleSettingDetailTable(EntityIUserAutoSaleSettingDetail[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.PossessionAutoSaleItemType);
    }

    public bool TryFindByUserIdAndPossessionAutoSaleItemType(ValueTuple<long, int> key, out EntityIUserAutoSaleSettingDetail result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key, out result);
}
