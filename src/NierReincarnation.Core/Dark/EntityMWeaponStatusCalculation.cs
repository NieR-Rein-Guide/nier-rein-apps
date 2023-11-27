﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMWeaponStatusCalculation))]
public class EntityMWeaponStatusCalculation
{
    [Key(0)]
    public int WeaponStatusCalculationId { get; set; }

    [Key(1)]
    public int HpNumericalFunctionId { get; set; }

    [Key(2)]
    public int AttackNumericalFunctionId { get; set; }

    [Key(3)]
    public int VitalityNumericalFunctionId { get; set; }
}
