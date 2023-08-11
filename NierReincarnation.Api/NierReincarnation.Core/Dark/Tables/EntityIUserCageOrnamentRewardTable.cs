using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserCageOrnamentRewardTable : TableBase<EntityIUserCageOrnamentReward>
{
    private readonly Func<EntityIUserCageOrnamentReward, (long, int)> primaryIndexSelector;

    public EntityIUserCageOrnamentRewardTable(EntityIUserCageOrnamentReward[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.UserId, element.CageOrnamentId);
    }

    public EntityIUserCageOrnamentReward FindByUserIdAndCageOrnamentId(ValueTuple<long, int> key) => FindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key);

    public bool TryFindByUserIdAndCageOrnamentId(ValueTuple<long, int> key, out EntityIUserCageOrnamentReward result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<(long, int)>.Default, key, out result);
}
