﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBigHuntBoss))]
public class EntityMBigHuntBoss
{
    [Key(0)]
    public int BigHuntBossId { get; set; }

    [Key(1)]
    public int BigHuntBossGradeGroupId { get; set; }

    [Key(2)]
    public int NameBigHuntBossTextId { get; set; }

    [Key(3)]
    public int BigHuntBossAssetId { get; set; }

    [Key(4)]
    public AttributeType AttributeType { get; set; }
}
