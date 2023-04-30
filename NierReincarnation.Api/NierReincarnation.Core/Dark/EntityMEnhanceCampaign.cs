using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_enhance_campaign")]
    public class EntityMEnhanceCampaign
    {
        [Key(0)]
        public int EnhanceCampaignId { get; set; } // 0x10

        [Key(1)]
        public int EnhanceCampaignTargetGroupId { get; set; } // 0x14

        [Key(2)]
        public EnhanceCampaignEffectType EnhanceCampaignEffectType { get; set; } // 0x18

        [Key(3)]
        public int EnhanceCampaignEffectValue { get; set; } // 0x1C

        [Key(4)]
        public long StartDatetime { get; set; } // 0x20

        [Key(5)]
        public long EndDatetime { get; set; } // 0x28

        [Key(6)]
        public TargetUserStatusType TargetUserStatusType { get; set; } // 0x30

        [Key(7)]
        public int SortOrder { get; set; } // 0x34
    }
}
