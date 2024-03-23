﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBattleNpcDeckLimitContentDeletedCharacter))]
public class EntityMBattleNpcDeckLimitContentDeletedCharacter
{
    [Key(0)]
    public long BattleNpcId { get; set; }

    [Key(1)]
    public int BattleNpcDeckNumber { get; set; }

    [Key(2)]
    public int BattleNpcDeckCharacterNumber { get; set; }

    [Key(3)]
    public int CostumeId { get; set; }
}
