using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_enhance_campaign_target_group")]
    public class EntityMEnhanceCampaignTargetGroup
    {
        [Key(0)]
        public int EnhanceCampaignTargetGroupId { get; set; }

        [Key(1)]
        public int EnhanceCampaignTargetIndex { get; set; }

        [Key(2)]
        public EnhanceCampaignTargetType EnhanceCampaignTargetType { get; set; }

        [Key(3)]
        public int EnhanceCampaignTargetValue { get; set; }
    }
}
