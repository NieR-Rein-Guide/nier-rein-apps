﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcCostumeLotteryEffectAbility))]
public class EntityMBattleNpcCostumeLotteryEffectAbility
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public string BattleNpcCostumeUuid { get; set; }

    [Key(2)]
    public int SlotNumber { get; set; }

    [Key(3)]
    public int AbilityId { get; set; }

    [Key(4)]
    public int AbilityLevel { get; set; }
}
