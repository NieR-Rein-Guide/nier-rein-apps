using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_beginner_campaign")]
    public class EntityIUserBeginnerCampaign
    {
        [Key(0)] // RVA: 0x1EAAA44 Offset: 0x1EAAA44 VA: 0x1EAAA44
        public long UserId { get; set; }
        [Key(1)] // RVA: 0x1EAAA84 Offset: 0x1EAAA84 VA: 0x1EAAA84
        public int BeginnerCampaignId { get; set; }
        [Key(2)] // RVA: 0x1EAAA98 Offset: 0x1EAAA98 VA: 0x1EAAA98
        public long CampaignRegisterDatetime { get; set; }
        [Key(3)] // RVA: 0x1EAAAAC Offset: 0x1EAAAAC VA: 0x1EAAAAC
        public long LatestVersion { get; set; }
	}
}
