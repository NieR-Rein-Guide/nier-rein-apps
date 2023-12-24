using NierReincarnation.Api.Model;
using NierReincarnation.Core.Dark.EntryPoint;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace NierReincarnation.Api.Command;

public class GetNoticeDetailsCommand : IAsyncCommand<GetNoticeDetailsCommandArg, GetNoticeDetailsCommandResult>
{
    private record ListRequest(CommonRequest CommonRequest, int[] InformationTypeList, string IsIngame, int Limit, int Offset);

    private readonly JsonSerializerOptions JsonSerializerOptions = new(JsonSerializerDefaults.Web);

    public async Task<GetNoticeDetailsCommandResult> ExecuteAsync(GetNoticeDetailsCommandArg arg)
    {
        // Create HTTP client
        using HttpClient httpClient = new()
        {
            DefaultRequestVersion = HttpVersion.Version20,
        };
        SetHeaders(httpClient);

        // Prepare the request
        NoticeDetailsRequest noticeDetailsRequest = new(new CommonRequest(), arg.NoticeId);

        // Send the request
        HttpResponseMessage response = await httpClient.PostAsync(Config.Api.NoticeDetailsGetUrl,
            new StringContent(JsonSerializer.Serialize(noticeDetailsRequest, JsonSerializerOptions),
            Encoding.UTF8, "application/json"));

        // Parse the response
        NoticeDetailsResponse? noticeDetailsResponse = response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<NoticeDetailsResponse>()
            : default;

        // Return the result
        return new GetNoticeDetailsCommandResult
        {
            NoticeDetails = noticeDetailsResponse is not null
                ? new NoticeDetailsItem()
                {
                    Title = noticeDetailsResponse.Title,
                    Body = noticeDetailsResponse.Body,
                    InformationType = noticeDetailsResponse.InformationType,
                    PublishDateTime = CalculatorDateTime.FromUnixTime(noticeDetailsResponse.PublishStartDatetime),
                    PostscriptDateTime = noticeDetailsResponse.PostscriptDatetime.HasValue
                        ? CalculatorDateTime.FromUnixTime(noticeDetailsResponse.PostscriptDatetime.Value)
                        : null
                }
                : default
        };
    }

    private static void SetHeaders(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));
    }
}

public class GetNoticeDetailsCommandArg
{
    public int NoticeId { get; init; }
}

public class GetNoticeDetailsCommandResult
{
    public NoticeDetailsItem? NoticeDetails { get; init; }
}
