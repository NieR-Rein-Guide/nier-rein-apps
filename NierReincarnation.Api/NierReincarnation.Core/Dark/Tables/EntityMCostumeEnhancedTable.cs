using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCostumeEnhancedTable : TableBase<EntityMCostumeEnhanced>
{
    private readonly Func<EntityMCostumeEnhanced, int> primaryIndexSelector;

    public EntityMCostumeEnhancedTable(EntityMCostumeEnhanced[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.CostumeEnhancedId;
    }

    public bool TryFindByCostumeEnhancedId(int key, out EntityMCostumeEnhanced result) => TryFindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key, out result);
}
