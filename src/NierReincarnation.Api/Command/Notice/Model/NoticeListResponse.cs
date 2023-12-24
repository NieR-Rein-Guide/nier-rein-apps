using NierReincarnation.Api.Model;

namespace NierReincarnation.Api.Command.Notice.Model;

internal record NoticeListResponse(long ResponseDatetime = 0) : CommonResponse(ResponseDatetime)
{
    public List<NoticeListItem> InformationList { get; init; } = [];
}