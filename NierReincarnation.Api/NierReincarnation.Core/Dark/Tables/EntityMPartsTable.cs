using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMPartsTable : TableBase<EntityMParts>
{
    private readonly Func<EntityMParts, int> primaryIndexSelector;

    public EntityMPartsTable(EntityMParts[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.PartsId;
    }

    public EntityMParts FindByPartsId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
