using NierReincarnation.Context.Models.Web;

namespace NierReincarnation.Api.Model;

public class NoticeListItem
{
    public int InformationId { get; init; }

    public InformationType InformationType { get; init; }

    public long PostscriptDatetime { get; init; }

    public long PublishStartDatetime { get; init; }

    public string ThumbnailImagePath { get; init; }

    public string Title { get; init; }

    public int WebviewMissionId { get; init; }
}
