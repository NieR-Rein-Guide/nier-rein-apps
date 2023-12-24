using NierReincarnation.Api.Command.Notice.Model;
using NierReincarnation.Api.Model;
using NierReincarnation.Core.Dark.EntryPoint;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace NierReincarnation.Api.Command;

public class GetNoticeBannerListCommand : IAsyncCommand<GetNoticeBannerListCommandArg, GetNoticeBannerListCommandResult>
{
    private readonly JsonSerializerOptions JsonSerializerOptions = new(JsonSerializerDefaults.Web);

    public async Task<GetNoticeBannerListCommandResult> ExecuteAsync(GetNoticeBannerListCommandArg arg)
    {
        // Create HTTP client
        using HttpClient httpClient = new()
        {
            DefaultRequestVersion = HttpVersion.Version20,
        };
        SetHeaders(httpClient);

        // Prepare the request
        NoticeBannerListRequest noticeListRequest = new(new CommonRequest(), arg.InformationTypeList.Select(x => (int)x).ToArray(), arg.IsIngame.ToString(), arg.PageSize, arg.PageIndex + 1);

        // Send the request
        HttpResponseMessage response = await httpClient.PostAsync(Config.Api.NoticeListGetUrl,
            new StringContent(JsonSerializer.Serialize(noticeListRequest, JsonSerializerOptions),
            Encoding.UTF8, "application/json"));

        // Parse the response
        NoticeBannerListResponse? noticeListResponse = response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<NoticeBannerListResponse>()
            : default;

        // Return the result
        return new GetNoticeBannerListCommandResult
        {
            BannerList = noticeListResponse?.BannerList ?? []
        };
    }

    private static void SetHeaders(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));
    }
}

public class GetNoticeBannerListCommandArg
{
    public InformationType[] InformationTypeList { get; init; } = (InformationType[])Enum.GetValues(typeof(InformationType));

    public bool IsIngame { get; init; }

    public int PageIndex { get; init; }

    public int PageSize { get; init; }
}

public class GetNoticeBannerListCommandResult
{
    public List<NoticeBannerListItem> BannerList { get; init; } = [];
}
