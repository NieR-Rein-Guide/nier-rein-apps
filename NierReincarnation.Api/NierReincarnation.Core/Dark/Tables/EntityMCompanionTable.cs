using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCompanionTable : TableBase<EntityMCompanion>
{
    private readonly Func<EntityMCompanion, int> primaryIndexSelector;

    public EntityMCompanionTable(EntityMCompanion[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.CompanionId;
    }

    public EntityMCompanion FindByCompanionId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
