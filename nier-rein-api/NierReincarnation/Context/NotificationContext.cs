using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using NierReincarnation.Context.Models;
using NierReincarnation.Context.Models.Web;
using NierReincarnation.Context.Support;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Dark.EntryPoint;
using NierReincarnation.Core.Dark.Preference;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Context
{
    public class NotificationContext
    {
        private readonly HttpClient _client;

        internal NotificationContext()
        {
            _client = new HttpClient();
        }

        public async IAsyncEnumerable<NotificationSummary> GetNotifications(int page = 1, int perPage = 10)
        {
            if (page <= 0 || perPage <= 0)
                yield break;

            var req = WebApiSupport.CreateRequest(HttpMethod.Post, new Uri("https://api-web.app.nierreincarnation.com/api/information/list/get"));
            req.Headers.Referrer = CreateReferrer();

            req.Content = JsonContent.Create(new NotificationListRequest
            {
                offset = (page - 1) * perPage + 1,
                limit = perPage
            });

            var res = await _client.SendAsync(req);
            if (!res.IsSuccessStatusCode)
                yield break;

            var resCont = await res.Content.ReadAsStringAsync();
            foreach (var notification in JsonConvert.DeserializeObject<NotificationListResponse>(resCont)?.informationList ?? Array.Empty<NotificationSummary>())
                yield return notification;
        }

        public async Task<object> GetNotification(int informationId)
        {
            var req = WebApiSupport.CreateRequest(HttpMethod.Post, new Uri("https://api-web.app.nierreincarnation.com/api/information/detail/get"));
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

        private Uri CreateReferrer()
        {
            var informationUri = Config.Api.MakeWebViewInformationPageUrl();
            var parameters = new[]
            {
                $"userId={ApplicationScopeClientContext.Instance.User.UserId}",
                $"playerId={PlayerPreference.Instance.ActivePlayer.PlayerId}",
                $"sessionKey={ApplicationScopeClientContext.Instance.Auth.SessionKey}",
                $"appVersion={Application.Version}",
                $"language={Application.SystemLanguage}",
                $"osVersion={HttpUtility.UrlEncode(SystemInfo.OperatingSystem)}",
                $"deviceName={HttpUtility.UrlEncode(SystemInfo.OperatingSystem)}",
                $"serverAddress={Config.Api.GetHostname(Application.Language)}",
                $"token={ApplicationScopeClientContext.Instance.Token.Value}",
                $"osType={(int)Application.Platform}",
                $"platformType={(int)Application.Platform}",
                "isIngame=False",
                "seVolume=0.7"
            };

            return new Uri(informationUri + string.Join("&", parameters));
        }
    }

    class NotificationListRequest
    {
        public CommonRequest commonRequest { get; set; } = new CommonRequest();
        public int[] informationTypeList { get; set; } = Enumerable.Range(1, 11).ToArray();
        public string isIngame { get; set; } = "True";
        public int limit { get; set; }
        public int offset { get; set; }
        public string sessionKey { get; set; } = ApplicationScopeClientContext.Instance.Auth.SessionKey;
        public string userIdString { get; set; } = $"{ApplicationScopeClientContext.Instance.User.UserId}";
    }

    class NotificationRequest
    {
        public CommonRequest commonRequest { get; set; } = new CommonRequest();
        public int informationId { get; set; }
        public string userIdString { get; set; } = $"{ApplicationScopeClientContext.Instance.User.UserId}";
    }

    class NotificationListResponse
    {
        public CommonResponse commonResponse { get; set; }
        public NotificationSummary[] informationList { get; set; }
    }

    class NotificationResponse
    {
        public string body { get; set; }
        public CommonResponse commonResponse { get; set; }
        public InformationType informationType { get; set; }
        public long postscriptDatetime { get; set; }
        public long publishStartDatetime { get; set; }
        public string title { get; set; }
    }
}
