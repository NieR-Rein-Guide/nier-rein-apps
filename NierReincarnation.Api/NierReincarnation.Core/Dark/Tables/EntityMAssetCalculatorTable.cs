using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMAssetCalculatorTable : TableBase<EntityMAssetCalculator>
{
    private readonly Func<EntityMAssetCalculator, int> primaryIndexSelector;

    public EntityMAssetCalculatorTable(EntityMAssetCalculator[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.AssetCalculatorId;
    }

    public EntityMAssetCalculator FindByAssetCalculatorId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
