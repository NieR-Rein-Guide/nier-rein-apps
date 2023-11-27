﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestBonusCostumeSettingGroup))]
public class EntityMQuestBonusCostumeSettingGroup
{
    [Key(0)]
    public int QuestBonusCostumeSettingGroupId { get; set; }

    [Key(1)]
    public int CostumeId { get; set; }

    [Key(2)]
    public int LimitBreakCountLowerLimit { get; set; }

    [Key(3)]
    public int QuestBonusEffectGroupId { get; set; }

    [Key(4)]
    public int QuestBonusTermGroupId { get; set; }
}
