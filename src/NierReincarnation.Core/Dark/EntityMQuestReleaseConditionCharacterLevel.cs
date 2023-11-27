﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestReleaseConditionCharacterLevel))]
public class EntityMQuestReleaseConditionCharacterLevel
{
    [Key(0)]
    public int QuestReleaseConditionId { get; set; }

    [Key(1)]
    public int CharacterId { get; set; }

    [Key(2)]
    public int CharacterLevel { get; set; }
}
