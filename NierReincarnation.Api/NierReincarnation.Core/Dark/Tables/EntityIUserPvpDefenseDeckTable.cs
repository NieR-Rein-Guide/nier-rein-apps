using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityIUserPvpDefenseDeckTable : TableBase<EntityIUserPvpDefenseDeck>
{
    private readonly Func<EntityIUserPvpDefenseDeck, long> primaryIndexSelector;

    public EntityIUserPvpDefenseDeckTable(EntityIUserPvpDefenseDeck[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.UserId;
    }

    public EntityIUserPvpDefenseDeck FindByUserId(long key) => FindUniqueCore(data, primaryIndexSelector, Comparer<long>.Default, key);
}
