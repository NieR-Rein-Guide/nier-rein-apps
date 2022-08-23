using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_campaign_target_group")]
    public class EntityMQuestCampaignTargetGroup
    {
        [Key(0)] // RVA: 0x1DE1E08 Offset: 0x1DE1E08 VA: 0x1DE1E08
        public int QuestCampaignTargetGroupId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1DE1E48 Offset: 0x1DE1E48 VA: 0x1DE1E48
        public int QuestCampaignTargetIndex { get; set; } // 0x14
        [Key(2)] // RVA: 0x1DE1E88 Offset: 0x1DE1E88 VA: 0x1DE1E88
        public QuestCampaignTargetType QuestCampaignTargetType { get; set; } // 0x18
        [Key(3)] // RVA: 0x1DE1E9C Offset: 0x1DE1E9C VA: 0x1DE1E9C
        public int QuestCampaignTargetValue { get; set; } // 0x1C
	}
}
