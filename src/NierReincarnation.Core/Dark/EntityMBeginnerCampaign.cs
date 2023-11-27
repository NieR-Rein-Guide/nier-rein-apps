﻿using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMBeginnerCampaign))]
public class EntityMBeginnerCampaign
{
    [Key(0)]
    public int BeginnerCampaignId { get; set; }

    [Key(1)]
    public long BeginnerJudgeStartDatetime { get; set; }

    [Key(2)]
    public long BeginnerJudgeEndDatetime { get; set; }

    [Key(3)]
    public int GrantCampaignTermDayCount { get; set; }

    [Key(4)]
    public int CampaignUnlockQuestId { get; set; }
}
