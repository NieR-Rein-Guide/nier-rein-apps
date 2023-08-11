using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMCompanionAbilityGroupTable : TableBase<EntityMCompanionAbilityGroup>
{
    private readonly Func<EntityMCompanionAbilityGroup, (int, int)> primaryIndexSelector;

    public EntityMCompanionAbilityGroupTable(EntityMCompanionAbilityGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.CompanionAbilityGroupId, element.SlotNumber);
    }

    public EntityMCompanionAbilityGroup FindByCompanionAbilityGroupIdAndSlotNumber(ValueTuple<int, int> key) => FindUniqueCore(data, primaryIndexSelector, Comparer<(int, int)>.Default, key);
}
