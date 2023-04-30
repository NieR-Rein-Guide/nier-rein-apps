using MessagePack;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_quest_campaign")]
    public class EntityMQuestCampaign
    {
        [Key(0)] // RVA: 0x1DE1CD0 Offset: 0x1DE1CD0 VA: 0x1DE1CD0
        public int QuestCampaignId { get; set; } // 0x10

        [Key(1)] // RVA: 0x1DE1D10 Offset: 0x1DE1D10 VA: 0x1DE1D10
        public int QuestCampaignTargetGroupId { get; set; } // 0x14

        [Key(2)] // RVA: 0x1DE1D24 Offset: 0x1DE1D24 VA: 0x1DE1D24
        public int QuestCampaignEffectGroupId { get; set; } // 0x18

        [Key(3)] // RVA: 0x1DE1D38 Offset: 0x1DE1D38 VA: 0x1DE1D38
        public long StartDatetime { get; set; } // 0x20

        [Key(4)] // RVA: 0x1DE1D4C Offset: 0x1DE1D4C VA: 0x1DE1D4C
        public long EndDatetime { get; set; } // 0x28

        [Key(5)] // RVA: 0x1EA493C Offset: 0x1EA493C VA: 0x1EA493C
        public TargetUserStatusType TargetUserStatusType { get; set; } // 0x30

        [Key(6)] // RVA: 0x1EA4950 Offset: 0x1EA4950 VA: 0x1EA4950
        public int SortOrder { get; set; } // 0x34
    }
}
