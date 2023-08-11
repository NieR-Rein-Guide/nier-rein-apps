using NierReincarnation.Core.MasterMemory;
using System;
using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.Tables;

public class EntityMWeaponStatusCalculationTable : TableBase<EntityMWeaponStatusCalculation>
{
    private readonly Func<EntityMWeaponStatusCalculation, int> primaryIndexSelector;

    public EntityMWeaponStatusCalculationTable(EntityMWeaponStatusCalculation[] sortedData) : base(sortedData)
    {
        primaryIndexSelector = element => element.WeaponStatusCalculationId;
    }

    public EntityMWeaponStatusCalculation FindByWeaponStatusCalculationId(int key) => FindUniqueCore(data, primaryIndexSelector, Comparer<int>.Default, key);
}
