using System.Collections.Generic;

namespace NierReincarnation.Core.Dark.View.UserInterface.Outgame;

public class DataCampaigns
{
    public List<DataCampaign> StandardCampaignList { get; set; }
    public List<DataCampaign> SpecialCampaignList { get; set; }
    public List<DataCampaign> TotalCampaignList { get; }

    public DataCampaigns()
    {
        StandardCampaignList = new List<DataCampaign>();
        SpecialCampaignList = new List<DataCampaign>();
        TotalCampaignList = new List<DataCampaign>();
    }
}
