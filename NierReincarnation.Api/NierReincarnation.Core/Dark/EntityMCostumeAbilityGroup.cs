﻿using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_ability_group")]
public class EntityMCostumeAbilityGroup
{
    [Key(0)] // RVA: 0x1DDBF18 Offset: 0x1DDBF18 VA: 0x1DDBF18
    public int CostumeAbilityGroupId { get; set; }

    [Key(1)] // RVA: 0x1DDBF80 Offset: 0x1DDBF80 VA: 0x1DDBF80
    public int SlotNumber { get; set; }

    [Key(2)] // RVA: 0x1DDBFC0 Offset: 0x1DDBFC0 VA: 0x1DDBFC0
    public int AbilityId { get; set; }

    [Key(3)] // RVA: 0x1DDBFD4 Offset: 0x1DDBFD4 VA: 0x1DDBFD4
    public int CostumeAbilityLevelGroupId { get; set; }
}
