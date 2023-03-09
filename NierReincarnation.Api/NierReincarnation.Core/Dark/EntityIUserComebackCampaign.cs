using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_comeback_campaign")]
    public class EntityIUserComebackCampaign
    {
        [Key(0)] // RVA: 0x1EAB45C Offset: 0x1EAB45C VA: 0x1EAB45C
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1EAB49C Offset: 0x1EAB49C VA: 0x1EAB49C
        public int ComebackCampaignId { get; set; }
        [Key(2)] // RVA: 0x1EAB4B0 Offset: 0x1EAB4B0 VA: 0x1EAB4B0
        public long ComebackDatetime { get; set; }
        [Key(3)] // RVA: 0x1EAB4C4 Offset: 0x1EAB4C4 VA: 0x1EAB4C4
        public long LatestVersion { get; set; }
	}
}
