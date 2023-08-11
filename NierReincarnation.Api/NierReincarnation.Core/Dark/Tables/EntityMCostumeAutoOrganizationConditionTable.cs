using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCostumeAutoOrganizationConditionTable : TableBase<EntityMCostumeAutoOrganizationCondition>
{
    private readonly Func<EntityMCostumeAutoOrganizationCondition, (int, CostumeAutoOrganizationConditionType)> primaryIndexSelector;

    public EntityMCostumeAutoOrganizationConditionTable(EntityMCostumeAutoOrganizationCondition[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CostumeId, element.CostumeAutoOrganizationConditionType);
    }

    public bool TryFindByCostumeIdAndCostumeAutoOrganizationConditionType(ValueTuple<int, CostumeAutoOrganizationConditionType> key, out EntityMCostumeAutoOrganizationCondition result) =>
        TryFindUniqueCore(data, primaryIndexSelector, Comparer<(int, CostumeAutoOrganizationConditionType)>.Default, key, out result);

    public RangeView<EntityMCostumeAutoOrganizationCondition> FindRangeByCostumeIdAndCostumeAutoOrganizationConditionType(ValueTuple<int,
        CostumeAutoOrganizationConditionType> min, ValueTuple<int, CostumeAutoOrganizationConditionType> max, bool ascendant = true) =>
        FindUniqueRangeCore(data, primaryIndexSelector, Comparer<(int, CostumeAutoOrganizationConditionType)>.Default, min, max, ascendant);
}
