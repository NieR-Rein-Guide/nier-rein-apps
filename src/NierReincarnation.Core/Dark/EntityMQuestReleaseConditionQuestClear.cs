﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestReleaseConditionQuestClear))]
public class EntityMQuestReleaseConditionQuestClear
{
    [Key(0)]
    public int QuestReleaseConditionId { get; set; }

    [Key(1)]
    public int QuestId { get; set; }
}
