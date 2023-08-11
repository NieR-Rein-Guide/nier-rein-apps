using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBattleActorAiTable : TableBase<EntityMBattleActorAi>
{
    private readonly Func<EntityMBattleActorAi, int> primaryIndexSelector;

    public EntityMBattleActorAiTable(EntityMBattleActorAi[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.BattleActorAiId;
    }

    public EntityMBattleActorAi FindByBattleActorAiId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
