﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMWeaponAbilityGroup))]
public class EntityMWeaponAbilityGroup
{
    [Key(0)]
    public int WeaponAbilityGroupId { get; set; }

    [Key(1)]
    public int SlotNumber { get; set; }

    [Key(2)]
    public int AbilityId { get; set; }

    [Key(3)]
    public int WeaponAbilityEnhancementMaterialId { get; set; }
}
