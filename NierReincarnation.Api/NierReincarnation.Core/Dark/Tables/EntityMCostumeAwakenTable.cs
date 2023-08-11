using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCostumeAwakenTable : TableBase<EntityMCostumeAwaken>
{
    private readonly Func<EntityMCostumeAwaken, int> primaryIndexSelector;

    public EntityMCostumeAwakenTable(EntityMCostumeAwaken[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.CostumeId;
    }

    public bool TryFindByCostumeId(int key, out EntityMCostumeAwaken result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
