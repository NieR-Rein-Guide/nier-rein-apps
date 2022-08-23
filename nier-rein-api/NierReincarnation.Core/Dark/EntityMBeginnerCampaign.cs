using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("m_beginner_campaign")]
    public class EntityMBeginnerCampaign
	{
        [Key(0)] // RVA: 0x1E9B110 Offset: 0x1E9B110 VA: 0x1E9B110
        public int BeginnerCampaignId { get; set; } // 0x10
        [Key(1)] // RVA: 0x1E9B150 Offset: 0x1E9B150 VA: 0x1E9B150
        public long BeginnerJudgeStartDatetime { get; set; } // 0x18
        [Key(2)] // RVA: 0x1E9B164 Offset: 0x1E9B164 VA: 0x1E9B164
        public long BeginnerJudgeEndDatetime { get; set; } // 0x20
        [Key(3)] // RVA: 0x1E9B178 Offset: 0x1E9B178 VA: 0x1E9B178
        public int GrantCampaignTermDayCount { get; set; } // 0x28
        [Key(4)] // RVA: 0x1E9B18C Offset: 0x1E9B18C VA: 0x1E9B18C
        public int CampaignUnlockQuestId { get; set; } // 0x2C
	}
}
