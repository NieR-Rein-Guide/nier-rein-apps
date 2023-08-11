using MessagePack;
using NierReincarnation.Core.MasterMemory;

namespace NierReincarnation.Core.Dark
{
    [MessagePackObject]
    [MemoryTable("i_user_comeback_campaign")]
    public class EntityIUserComebackCampaign
    {
        [Key(0)]
        public long UserId { get; set; }

        [Key(1)]
        public int ComebackCampaignId { get; set; }

        [Key(2)]
        public long ComebackDatetime { get; set; }

        [Key(3)]
        public long LatestVersion { get; set; }
    }
}
