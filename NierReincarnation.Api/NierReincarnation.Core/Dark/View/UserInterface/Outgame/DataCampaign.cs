using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame;

public class DataCampaign
{
    private int campaignId;

    public CampaignType CampaignType { get; set; }

    public int CampaignId { set => campaignId = value; }

    public TargetUserStatusType TargetUserStatusType { get; set; }

    public int SortOrder { get; set; }

    public long EndTime { get; set; }
}
