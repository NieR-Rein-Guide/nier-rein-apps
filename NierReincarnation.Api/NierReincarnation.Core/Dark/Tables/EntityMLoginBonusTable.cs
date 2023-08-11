using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMLoginBonusTable : TableBase<EntityMLoginBonus>
{
    private readonly Func<EntityMLoginBonus, int> primaryIndexSelector;

    public EntityMLoginBonusTable(EntityMLoginBonus[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.LoginBonusId;
    }

    public EntityMLoginBonus FindByLoginBonusId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
