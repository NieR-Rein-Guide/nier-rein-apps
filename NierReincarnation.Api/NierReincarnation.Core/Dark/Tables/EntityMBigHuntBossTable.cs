using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMBigHuntBossTable : TableBase<EntityMBigHuntBoss>
{
    private readonly Func<EntityMBigHuntBoss, int> primaryIndexSelector;

    public EntityMBigHuntBossTable(EntityMBigHuntBoss[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.BigHuntBossId;
    }

    public EntityMBigHuntBoss FindByBigHuntBossId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
