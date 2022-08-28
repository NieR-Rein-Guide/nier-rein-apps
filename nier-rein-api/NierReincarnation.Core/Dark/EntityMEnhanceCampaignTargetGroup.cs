using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_enhance_campaign_target_group")]
    public class EntityMEnhanceCampaignTargetGroup
    {
        [Key(0)]
        public int EnhanceCampaignTargetGroupId { get; set; } // 0x10
        [Key(1)]
        public int EnhanceCampaignTargetIndex { get; set; } // 0x14
        [Key(2)]
        public int EnhanceCampaignTargetType { get; set; } // 0x18
        [Key(3)]
        public int EnhanceCampaignTargetValue { get; set; } // 0x1C
    }
}