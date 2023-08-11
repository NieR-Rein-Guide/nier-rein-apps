using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCostumeAbilityLevelGroupTable : TableBase<EntityMCostumeAbilityLevelGroup>
{
    private readonly Func<EntityMCostumeAbilityLevelGroup, (int, int)> primaryIndexSelector;

    public EntityMCostumeAbilityLevelGroupTable(EntityMCostumeAbilityLevelGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CostumeAbilityLevelGroupId, element.CostumeLimitBreakCountLowerLimit);
    }

    public EntityMCostumeAbilityLevelGroup FindClosestByCostumeAbilityLevelGroupIdAndCostumeLimitBreakCountLowerLimit(ValueTuple<int, int> key, bool selectLower = true) =>
        FindUniqueClosestCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key, selectLower);
}
