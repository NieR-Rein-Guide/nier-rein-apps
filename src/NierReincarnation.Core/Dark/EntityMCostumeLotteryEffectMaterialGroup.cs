﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_costume_lottery_effect_material_group")]
public class EntityMCostumeLotteryEffectMaterialGroup
{
    [Key(0)]
    public int CostumeLotteryEffectMaterialGroupId { get; set; }

    [Key(1)]
    public int MaterialId { get; set; }

    [Key(2)]
    public int Count { get; set; }

    [Key(3)]
    public int SortOrder { get; set; }
}