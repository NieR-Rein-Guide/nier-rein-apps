using NierReincarnation.Api.Command;
using NierReincarnation.Api.Model;

namespace NierReincarnation.Api.Service;

public static class NoticeService
{
    /// <summary>
    /// Gets a list of all in-game notices
    /// </summary>
    /// <param name="informationTypes">The type of notices</param>
    /// <param name="pageIndex">The page index</param>
    /// <param name="pageSize">The page size</param>
    /// <returns></returns>
    public static async Task<List<NoticeListItem>> GetNoticesAsync(InformationType[] informationTypes, int pageIndex = 0, int pageSize = 10)
    {
        var noticeListResult = await new GetNoticeListCommand().ExecuteAsync(new GetNoticeListCommandArg
        {
            InformationTypeList = informationTypes,
            IsIngame = true,
            PageIndex = pageIndex,
            PageSize = pageSize
        });

        return noticeListResult.NoticeList;
    }

    /// <summary>
    /// Gets the details of a specific in-game notice
    /// </summary>
    /// <param name="noticeId">The notice ID</param>
    /// <returns></returns>
    public static async Task<NoticeDetailsItem?> GetNoticeAsync(int noticeId)
    {
        var noticeDetailsResult = await new GetNoticeDetailsCommand().ExecuteAsync(new GetNoticeDetailsCommandArg
        {
            NoticeId = noticeId
        });

        return noticeDetailsResult.NoticeDetails;
    }

    /// <summary>
    /// Gets a list of all in-game notice banners
    /// </summary>
    /// <param name="informationTypes">The type of notices</param>
    /// <param name="pageIndex">The page index</param>
    /// <param name="pageSize">The page size</param>
    /// <returns></returns>
    public static async Task<List<NoticeBannerListItem>> GetNoticeBannersAsync(InformationType[] informationTypes, int pageIndex = 0, int pageSize = 10)
    {
        var noticeListResult = await new GetNoticeBannerListCommand().ExecuteAsync(new GetNoticeBannerListCommandArg
        {
            InformationTypeList = informationTypes,
            IsIngame = true,
            PageIndex = pageIndex,
            PageSize = pageSize
        });

        return noticeListResult.BannerList;
    }
}
