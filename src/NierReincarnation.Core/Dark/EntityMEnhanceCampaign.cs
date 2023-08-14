using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_enhance_campaign")]
public class EntityMEnhanceCampaign
{
    [Key(0)]
    public int EnhanceCampaignId { get; set; }

    [Key(1)]
    public int EnhanceCampaignTargetGroupId { get; set; }

    [Key(2)]
    public EnhanceCampaignEffectType EnhanceCampaignEffectType { get; set; }

    [Key(3)]
    public int EnhanceCampaignEffectValue { get; set; }

    [Key(4)]
    public long StartDatetime { get; set; }

    [Key(5)]
    public long EndDatetime { get; set; }

    [Key(6)]
    public TargetUserStatusType TargetUserStatusType { get; set; }

    [Key(7)]
    public int SortOrder { get; set; }
}
