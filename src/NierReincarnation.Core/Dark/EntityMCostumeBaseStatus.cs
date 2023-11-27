﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMCostumeBaseStatus))]
public class EntityMCostumeBaseStatus
{
    [Key(0)]
    public int CostumeBaseStatusId { get; set; }

    [Key(1)]
    public int Hp { get; set; }

    [Key(2)]
    public int Attack { get; set; }

    [Key(3)]
    public int Vitality { get; set; }

    [Key(4)]
    public int Agility { get; set; }

    [Key(5)]
    public int CriticalRatioPermil { get; set; }

    [Key(6)]
    public int CriticalAttackRatioPermil { get; set; }

    [Key(7)]
    public int EvasionRatioPermil { get; set; }
}
