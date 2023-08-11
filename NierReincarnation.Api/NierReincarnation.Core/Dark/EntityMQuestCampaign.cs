using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_quest_campaign")]
public class EntityMQuestCampaign
{
    [Key(0)] // RVA: 0x1DE1CD0 Offset: 0x1DE1CD0 VA: 0x1DE1CD0
    public int QuestCampaignId { get; set; }

    [Key(1)] // RVA: 0x1DE1D10 Offset: 0x1DE1D10 VA: 0x1DE1D10
    public int QuestCampaignTargetGroupId { get; set; }

    [Key(2)] // RVA: 0x1DE1D24 Offset: 0x1DE1D24 VA: 0x1DE1D24
    public int QuestCampaignEffectGroupId { get; set; }

    [Key(3)] // RVA: 0x1DE1D38 Offset: 0x1DE1D38 VA: 0x1DE1D38
    public long StartDatetime { get; set; }

    [Key(4)] // RVA: 0x1DE1D4C Offset: 0x1DE1D4C VA: 0x1DE1D4C
    public long EndDatetime { get; set; }

    [Key(5)] // RVA: 0x1EA493C Offset: 0x1EA493C VA: 0x1EA493C
    public TargetUserStatusType TargetUserStatusType { get; set; }

    [Key(6)] // RVA: 0x1EA4950 Offset: 0x1EA4950 VA: 0x1EA4950
    public int SortOrder { get; set; }
}
