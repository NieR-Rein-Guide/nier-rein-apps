namespace NierReincarnation.Context.Models.Web;

public class NotificationSummary
{
    public int informationId { get; set; }

    public InformationType informationType { get; set; }

    public long postscriptDatetime { get; set; }

    public long publishStartDatetime { get; set; }

    public string thumbnailImagePath { get; set; }

    public string title { get; set; }

    public int webviewMissionId { get; set; }
}
