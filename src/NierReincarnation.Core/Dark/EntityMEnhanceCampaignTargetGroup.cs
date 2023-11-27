using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable(nameof(EntityMEnhanceCampaignTargetGroup))]
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
