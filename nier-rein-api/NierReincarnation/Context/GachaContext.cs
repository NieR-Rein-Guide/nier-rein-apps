using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;
using Art.Framework.ApiNetwork.Grpc.Api.Gacha;
using Newtonsoft.Json;
using NierReincarnation.Context.Models;
using NierReincarnation.Context.Models.Web;
using NierReincarnation.Context.Support;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.Dark.EntryPoint;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.Preference;
using NierReincarnation.Core.UnityEngine;
using NierReincarnation.Localizations;

namespace NierReincarnation.Context
{
    public class GachaContext
    {
        private readonly HttpClient _client;
        private readonly DarkClient _dc;

        internal GachaContext(DarkClient dc)
        {
            _dc = dc;
            _client = new HttpClient();
        }

        public async IAsyncEnumerable<Banner> GetBanners()
        {
            var gachaListRes = await _dc.GachaService.GetGachaListAsync(new GetGachaListRequest
            {
                GachaLabelType =
                {
                    (int)GachaLabelType.PREMIUM,
                    (int)GachaLabelType.EVENT,
                    (int)GachaLabelType.CHAPTER,
                    (int)GachaLabelType.PORTAL_CAGE
                }
            });

            foreach (var banner in gachaListRes.Gacha)
            {
                string id = null;
                switch (banner.GachaModeCase)
                {
                    case Gacha.GachaModeOneofCase.Basic:
                        id = banner.Basic.GachaAssetName;
                        break;

                    case Gacha.GachaModeOneofCase.Stepup:
                        id = banner.Stepup.GachaAssetName;
                        break;

                    case Gacha.GachaModeOneofCase.Box:
                        id = banner.Box.GachaAssetName;
                        break;
                }

                yield return new Banner
                {
                    GachaId = banner.GachaId,

                    Name = $"gacha.title.{id}".Localize(),

                    StartTime = banner.StartDatetime.ToDateTime(),
                    EndTime = banner.EndDatetime.ToDateTime(),

                    GachaLabelType = (GachaLabelType)banner.GachaLabelType,
                    GachaModeType = (GachaModeType)banner.GachaModeType,
                    GachaAutoResetType = (GachaAutoResetType)banner.GachaAutoResetType,
                    GachaDecorationType = (GachaDecorationType)banner.GachaDecorationType
                };
            }
        }

        public async Task<object> GetRates(int bannerId)
        {
            var req = WebApiSupport.CreateRequest(HttpMethod.Post, new Uri("https://api-web.app.nierreincarnation.com/api/gacha/odds"));
            req.Headers.Referrer = CreateReferrer(bannerId);

            req.Content = JsonContent.Create(new GachaRateRequest
            {
                gachaId = $"{bannerId}"
            });

            var res = await _client.SendAsync(req);
            if (!res.IsSuccessStatusCode)
                return null;

            var resCont = await res.Content.ReadAsStringAsync();
            var gachaRates = JsonConvert.DeserializeObject<GachaRateResponse>(resCont);

            return gachaRates?.basic ?? (object)gachaRates?.stepup ?? gachaRates?.box;
        }

        private Uri CreateReferrer(int gachaId)
        {
            var informationUri = Config.Api.MakeWebViewInformationPageUrl();
            var parameters = new[]
            {
                $"bannerId={gachaId}",
                "tab=Rate",
                $"userId={ApplicationScopeClientContext.Instance.User.UserId}",
                $"playerId={PlayerPreference.Instance.ActivePlayer.PlayerId}",
                $"sessionKey={ApplicationScopeClientContext.Instance.Auth.SessionKey}",
                $"appVersion={Application.Version}",
                $"language={Application.SystemLanguage}",
                $"osVersion={HttpUtility.UrlEncode(SystemInfo.OperatingSystem)}",
                $"deviceName={HttpUtility.UrlEncode(SystemInfo.OperatingSystem)}",
                $"serverAddress={Config.Api.Hostname}",
                $"token={ApplicationScopeClientContext.Instance.Token.Value}",
                $"osType={(int)Application.Platform}",
                $"platformType={(int)Application.Platform}",
                "isIngame=False",
                "seVolume=0.7"
            };

            return new Uri(informationUri + string.Join("&", parameters));
        }
    }

    class GachaRateRequest
    {
        public CommonRequest commonRequest { get; set; } = new CommonRequest();
        public string gachaId { get; set; }
        public string userIdString { get; set; } = $"{ApplicationScopeClientContext.Instance.User.UserId}";
    }

    class GachaRateResponse
    {
        public GachaLabelType gachaLabelType { get; set; }
        public GachaRateBasic basic { get; set; }
        public GachaRateStepup stepup { get; set; }
        public GachaRateBox box { get; set; }
        public CommonResponse commonResponse { get; set; }
    }
}
