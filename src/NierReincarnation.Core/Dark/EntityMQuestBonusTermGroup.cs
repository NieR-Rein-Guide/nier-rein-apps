﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestBonusTermGroup))]
public class EntityMQuestBonusTermGroup
{
    [Key(0)]
    public int QuestBonusTermGroupId { get; set; }

    [Key(1)]
    public int SortOrder { get; set; }

    [Key(2)]
    public long StartDatetime { get; set; }

    [Key(3)]
    public long EndDatetime { get; set; }
}
