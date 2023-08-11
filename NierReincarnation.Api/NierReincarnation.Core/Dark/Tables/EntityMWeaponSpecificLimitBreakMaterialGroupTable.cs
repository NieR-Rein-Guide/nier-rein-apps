using NierReincarnation.Core.MasterMemory;
using System;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMWeaponSpecificLimitBreakMaterialGroupTable : TableBase<EntityMWeaponSpecificLimitBreakMaterialGroup>
{
    private readonly Func<EntityMWeaponSpecificLimitBreakMaterialGroup, (int, int, int)> primaryIndexSelector;

    public EntityMWeaponSpecificLimitBreakMaterialGroupTable(EntityMWeaponSpecificLimitBreakMaterialGroup[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => (element.WeaponSpecificLimitBreakMaterialGroupId, element.LimitBreakCountLowerLimit, element.MaterialId);
    }
}
