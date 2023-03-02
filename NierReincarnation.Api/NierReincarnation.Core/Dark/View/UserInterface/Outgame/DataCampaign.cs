using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame
{
    public class DataCampaign
    {
        private int campaignId;

        // 0x10
        public CampaignType CampaignType { get; set; }
        // 0x14
        public int CampaignId { set => campaignId = value; }
        // 0x18
        public TargetUserStatusType TargetUserStatusType { get; set; }
        // 0x1C
        public int SortOrder { get; set; }
        // 0x20
        public long EndTime { get; set; }
	}
}
