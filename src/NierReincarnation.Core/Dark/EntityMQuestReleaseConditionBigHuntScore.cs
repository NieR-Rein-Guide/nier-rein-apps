﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestReleaseConditionBigHuntScore))]
public class EntityMQuestReleaseConditionBigHuntScore
{
    [Key(0)]
    public int QuestReleaseConditionId { get; set; }

    [Key(1)]
    public int BigHuntBossId { get; set; }

    [Key(2)]
    public long NecessaryScore { get; set; }
}
