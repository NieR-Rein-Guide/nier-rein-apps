using Newtonsoft.Json;
using NierReincarnation.Context.Models.Web;
using NierReincarnation.Context.Support;
using NierReincarnation.Core.Dark.EntryPoint;
using NierReincarnation.Core.UnityEngine;
using System.Net.Http.Json;
using System.Web;

namespace NierReincarnation.Context;

public class NotificationContext
{
    private readonly HttpClient _client;

    internal NotificationContext()
    {
        Generator.OnEntrypoint();

        _client = new HttpClient();
    }

    public async IAsyncEnumerable<NotificationSummary> GetAllNotifications()
    {
        var page = 1;
        const int offset = 10;

        var hasEntries = true;
        while (hasEntries)
        {
            hasEntries = false;

            await foreach (var notification in GetNotifications(page++, offset))
            {
                hasEntries = true;

                yield return notification;
            }
        }
    }

    public async IAsyncEnumerable<NotificationSummary> GetNotifications(int page, int perPage)
    {
        if (page <= 0 || perPage <= 0)
            yield break;

        var req = WebApiSupport.CreateRequest(HttpMethod.Post, new Uri(Config.Api.NotificationGetUrl));
        req.Headers.Referrer = CreateReferrer();

        req.Content = JsonContent.Create(new NotificationListRequest
        {
            offset = ((page - 1) * perPage) + 1,
            limit = perPage
        });

        var res = await _client.SendAsync(req);
        if (!res.IsSuccessStatusCode)
            yield break;

        var resCont = await res.Content.ReadAsStringAsync();
        foreach (var notification in JsonConvert.DeserializeObject<NotificationListResponse>(resCont)?.informationList ?? Array.Empty<NotificationSummary>())
            yield return notification;
    }

    public async Task<Notification> GetNotification(int informationId)
    {
        var req = WebApiSupport.CreateRequest(HttpMethod.Post, new Uri(Config.Api.NotificationDetailUrl));
        req.Headers.Referrer = CreateReferrer();

        req.Content = JsonContent.Create(new NotificationRequest
        {
            informationId = informationId
        });

        var res = await _client.SendAsync(req);
        if (!res.IsSuccessStatusCode)
            return null;

        var resCont = await res.Content.ReadAsStringAsync();
        var notification = JsonConvert.DeserializeObject<NotificationResponse>(resCont);
        if (notification == null)
            return null;

        return new Notification
        {
            informationType = notification.informationType,
            title = notification.title,
            body = notification.body,
            publishStartDatetime = notification.publishStartDatetime,
            postscriptDatetime = notification.postscriptDatetime
        };
    }

    private static Uri CreateReferrer()
    {
        var informationUri = Config.Api.MakeWebViewInformationPageUrl();
        var parameters = new[]
        {
            //$"userId={ApplicationScopeClientContext.Instance.User.UserId}",
            //$"playerId={PlayerPreference.Instance.ActivePlayer.PlayerId}",
            //$"sessionKey={ApplicationScopeClientContext.Instance.Auth.SessionKey}",
            $"appVersion={Application.Version}",
            $"language={Application.SystemLanguage}",
            $"osVersion={HttpUtility.UrlEncode(SystemInfo.OperatingSystem)}",
            $"deviceName={HttpUtility.UrlEncode(SystemInfo.OperatingSystem)}",
            $"serverAddress={Config.Api.Hostname}",
            //$"token={ApplicationScopeClientContext.Instance.Token.Value}",
            $"osType={(int)Application.Platform}",
            $"platformType={(int)Application.Platform}",
            "isIngame=False",
            "seVolume=0.7"
        };

        return new Uri(informationUri + string.Join("&", parameters));
    }
}

internal class NotificationListRequest
{
    public CommonRequest commonRequest { get; set; } = new CommonRequest();

    public int[] informationTypeList { get; set; } = Enumerable.Range(1, 11).ToArray();

    public string isIngame { get; set; } = "True";

    public int limit { get; set; }

    public int offset { get; set; }

    //public string sessionKey { get; set; } = ApplicationScopeClientContext.Instance.Auth.SessionKey;
    //public string userIdString { get; set; } = $"{ApplicationScopeClientContext.Instance.User.UserId}";
}

internal class NotificationRequest
{
    public CommonRequest commonRequest { get; set; } = new CommonRequest();

    public int informationId { get; set; }

    //public string userIdString { get; set; } = $"{ApplicationScopeClientContext.Instance.User.UserId}";
}

internal class NotificationListResponse
{
    public CommonResponse commonResponse { get; set; }

    public NotificationSummary[] informationList { get; set; }
}

internal class NotificationResponse
{
    public string body { get; set; }

    public CommonResponse commonResponse { get; set; }

    public InformationType informationType { get; set; }

    public long postscriptDatetime { get; set; }

    public long publishStartDatetime { get; set; }

    public string title { get; set; }
}
