using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_campaign_target_group")]
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
