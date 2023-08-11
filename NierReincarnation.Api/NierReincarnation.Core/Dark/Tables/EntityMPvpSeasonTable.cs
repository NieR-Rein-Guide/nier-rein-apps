using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMPvpSeasonTable : TableBase<EntityMPvpSeason>
{
    private readonly Func<EntityMPvpSeason, int> primaryIndexSelector;

    public EntityMPvpSeasonTable(EntityMPvpSeason[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.PvpSeasonId;
    }

    public EntityMPvpSeason FindByPvpSeasonId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);

    public bool TryFindByPvpSeasonId(int key, out EntityMPvpSeason result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
