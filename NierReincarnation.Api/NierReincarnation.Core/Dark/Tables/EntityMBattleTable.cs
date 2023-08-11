using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleTable : TableBase<EntityMBattle>
{
    private readonly Func<EntityMBattle, int> primaryIndexSelector;

    public EntityMBattleTable(EntityMBattle[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.BattleId;
    }

    public EntityMBattle FindByBattleId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);

    public bool TryFindByBattleId(int key, out EntityMBattle result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
