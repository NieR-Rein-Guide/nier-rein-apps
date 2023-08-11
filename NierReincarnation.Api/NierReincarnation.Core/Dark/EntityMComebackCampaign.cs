using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark;

[MessagePackObject]
[MemoryTable("m_comeback_campaign")]
public class EntityMComebackCampaign
{
    [Key(0)] // RVA: 0x1E9D034 Offset: 0x1E9D034 VA: 0x1E9D034
    public int ComebackCampaignId { get; set; }

    [Key(1)] // RVA: 0x1E9D074 Offset: 0x1E9D074 VA: 0x1E9D074
    public long ComebackJudgeStartDatetime { get; set; }

    [Key(2)] // RVA: 0x1E9D088 Offset: 0x1E9D088 VA: 0x1E9D088
    public long ComebackJudgeEndDatetime { get; set; }

    [Key(3)] // RVA: 0x1E9D09C Offset: 0x1E9D09C VA: 0x1E9D09C
    public int ComebackJudgeDayCount { get; set; }

    [Key(4)] // RVA: 0x1E9D0B0 Offset: 0x1E9D0B0 VA: 0x1E9D0B0
    public int GrantCampaignTermDayCount { get; set; }

    [Key(5)] // RVA: 0x1E9D0C4 Offset: 0x1E9D0C4 VA: 0x1E9D0C4
    public int CampaignUnlockQuestId { get; set; }

    [Key(6)] // RVA: 0x1F758C8 Offset: 0x1F758C8 VA: 0x1F758C8
    public int ComebackCampaignGradeGroupId { get; set; }
}
