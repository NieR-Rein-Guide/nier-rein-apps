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
        public long EndTime { get; set; }
    }
}
