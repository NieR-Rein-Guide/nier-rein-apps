using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_campaign_effect_group")]
public class EntityMQuestCampaignEffectGroup
{
    [Key(0)] // RVA: 0x1DE1D60 Offset: 0x1DE1D60 VA: 0x1DE1D60
    public int QuestCampaignEffectGroupId { get; set; }

    [Key(1)] // RVA: 0x1DE1DA0 Offset: 0x1DE1DA0 VA: 0x1DE1DA0
    public QuestCampaignEffectType QuestCampaignEffectType { get; set; }

    [Key(2)] // RVA: 0x1DE1DE0 Offset: 0x1DE1DE0 VA: 0x1DE1DE0
    public int QuestCampaignEffectValue { get; set; }

    [Key(3)] // RVA: 0x1DE1DF4 Offset: 0x1DE1DF4 VA: 0x1DE1DF4
    public int QuestCampaignTargetItemGroupId { get; set; }
}
