namespace NierReincarnation.Datamine.Model;

public class GachaModel
{
    public int GachaId { get; init; }

    public string Name { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int ItemsPerPull { get; set; }

    public List<RarityRateListModel> RarityRateList { get; set; }

    public List<RarityRateListModel> LastChanceRarityRateList { get; set; }

    public List<RarityRateDetailModel> RarityRateDetailList { get; set; }

    public List<RarityRateDetailModel> LastChanceRarityRateDetailList { get; set; }
}
