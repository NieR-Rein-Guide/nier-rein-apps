using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCostumeAbilityGroupTable : TableBase<EntityMCostumeAbilityGroup>
{
    private readonly Func<EntityMCostumeAbilityGroup, (int, int)> primaryIndexSelector;
    private readonly Func<EntityMCostumeAbilityGroup, int> secondaryIndexSelector;

    public EntityMCostumeAbilityGroupTable(EntityMCostumeAbilityGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CostumeAbilityGroupId, element.SlotNumber);
        secondaryIndexSelector = element => element.CostumeAbilityGroupId;
    }

    public RangeView<EntityMCostumeAbilityGroup> FindByCostumeAbilityGroupId(int key) => FindManyCore(data, secondaryIndexSelector, Comparer<int>.Default, key);
}
