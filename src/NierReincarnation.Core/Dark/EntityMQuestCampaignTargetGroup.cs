﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMQuestCampaignTargetGroup))]
public class EntityMQuestCampaignTargetGroup
{
    [Key(0)]
    public int QuestCampaignTargetGroupId { get; set; }

    [Key(1)]
    public int QuestCampaignTargetIndex { get; set; }

    [Key(2)]
    public QuestCampaignTargetType QuestCampaignTargetType { get; set; }

    [Key(3)]
    public int QuestCampaignTargetValue { get; set; }
}
