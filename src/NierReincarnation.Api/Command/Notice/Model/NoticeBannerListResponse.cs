using NierReincarnation.Api.Model;

namespace NierReincarnation.Api.Command.Notice.Model;

internal record NoticeBannerListResponse(long ResponseDatetime = 0) : CommonResponse(ResponseDatetime)
{
    public List<NoticeBannerListItem> BannerList { get; init; } = [];
}