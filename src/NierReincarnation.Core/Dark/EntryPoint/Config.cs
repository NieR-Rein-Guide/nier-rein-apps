using NierReincarnation.Core.Dark.Kernel;
using NierReincarnation.Core.Dark.Preference;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Dark.EntryPoint;

public static class Config
{
    // CUSTOM
    private static bool IsGlobal => Application.SystemRegion == SystemRegion.GL;

    public static class Api
    {
        private const string MasterDataDevUrlFormat = "https://dev-web.dark.abot.sh/assets/release/{0}/database.bin";

        public static string Hostname => IsGlobal
            ? "api.app.nierreincarnation.com"
            : "api.app.nierreincarnation.jp";

        public static readonly int Port = 443;

        public static string WebViewBaseUrl => IsGlobal
            ? "https://web.app.nierreincarnation.com"
            : "https://mama:na23R6uh7P@web.app.nierreincarnation.jp";

        public static string MasterDataUrlFormat => IsGlobal
            ? "https://web.app.nierreincarnation.com/assets/release/{0}/database.bin"
            : "https://web.app.nierreincarnation.jp/assets/release/{0}/database.bin";

        public static string Salt => IsGlobal
            ? "qxDjPftFRGc4aGpHtwZajxzV"
            : "qzn8MLVdfXEcNVuqEirJbogd";

        public static int BridgeGameId => IsGlobal ? 288 : 255;

        public static readonly string EncryptionMasterDataUrlSuffix = ".e";
        public static readonly string AccountRegisterUrl = "https://psg.sqex-bridge.jp/ntv/{0}/reg/top?type={1}&token={2}";
        public static readonly string AccountTransferUrl = "https://psg.sqex-bridge.jp/ntv/{0}/update/top?type={1}&token={2}";
        public static readonly int BridgeTypeId = 2;
        public static readonly string AmazonStoreURL = "amzn://apps/android?p=com.square_enix.android_amazon.nierspjp";

        public static string GoogleStoreUrl => IsGlobal
            ? "https://play.google.com/store/apps/details?id=com.square_enix.android_googleplay.nierspww"
            : "https://play.google.com/store/apps/details?id=com.square_enix.android_googleplay.nierspjp";

        public static string ItunesStoreUrl => IsGlobal
            ? "https://apps.apple.com/us/app/nier-re-in-carnation/id1506553488?mt=8"
            : "https://apps.apple.com/jp/app/id1504185645?mt=8";

        public static string SNSUrl => IsGlobal
            ? "https://twitter.com/NieRReinEN"
            : "https://twitter.com/nier_rein";

        private const string WebPagePath = "/web";
        private const string StaticPagePath = "/web/static";
        private const string InquiryPagePath = "/inquiry?";
        private const string InformationPagePath = "/information/?";
        private const string InformationPageQueryPathFormat = "informationId={0}&";
        public static readonly string WebviewMissionPageQueryPathFormat = "/panelmission/{0}?";
        public static readonly string TermsOfUsePagePath = "/terms/termsofuse";
        public static readonly string AgeVerificationPagePath = "/terms/ageverification";
        public static readonly string PersonalizeAddPagePath = "/terms/personalizeadd_1";
        public static readonly string LicensePagePath = "/terms/license";
        public static readonly string PrivacyPolicyPagePath = "/terms/privacypolicy";
        public static readonly string ActOnSettlementPagePath = "/terms/shikin";
        public static readonly string ActOnSpecifiedCommercialTransactions = "/terms/tokutei";
        public static readonly string MaintenancePagePath = "/system/maintenance";
        public static readonly string IndividualPopupPath = "/popup?detail={0}&";
        private const string SubQuestPlayGuidePagePath = "/sub-quest/?";
        private const string SubQuestPlayGuidePageQueryPathFormat = "playguideId={0}&";
        public static readonly string IronSourceAppKey = "100f45ad9";
        public static readonly string JaPagePath = "/ja";
        public static readonly string EnPagePath = "/en";
        public static readonly string KoPagePath = "/ko";

        // CUSTOM
        public static string NoticeListGetUrl => IsGlobal
            ? "https://api-web.app.nierreincarnation.com/api/information/list/get"
            : "https://api-web.app.nierreincarnation.jp/api/information/list/get";

        public static string NoticeDetailsGetUrl => IsGlobal
            ? "https://api-web.app.nierreincarnation.com/api/information/detail/get"
            : "https://api-web.app.nierreincarnation.jp/api/information/detail/get";

        public static string NoticeBannersGetUrl => IsGlobal
            ? "https://api-web.app.nierreincarnation.com/api/information/banner/list/get"
            : "https://api-web.app.nierreincarnation.jp/api/information/banner/list/get";

        public static string MakeMasterDataUrl(string masterVersion)
        {
            var urlFormat = ApplicationApi.IsReviewEnvironment()
                ? ApplicationApi.GetReviewUrlFormat()
                : MasterDataUrlFormat;

            return string.Format(urlFormat, masterVersion) + EncryptionMasterDataUrlSuffix;
        }

        public static string MakeFullWebViewWebPagePath(string path) => MakeWebViewUrl(WebPagePath, path);

        public static string MakeFullWebViewStaticPageUrl(string path) => MakeWebViewUrl(StaticPagePath, path);

        public static string MakeWebViewInquiryPageUrl(string query) => MakeFullWebViewWebPagePath(InquiryPagePath + query);

        public static string MakeWebViewInformationPageUrl() => MakeWebViewUrl(string.Empty, InformationPagePath);

        public static string MakeWebViewInformationPageUrl(int domainId) =>
            MakeWebViewUrl(string.Empty, InformationPagePath + string.Format(InformationPageQueryPathFormat, domainId));

        public static string MakeWebViewSubQuestPlayGuidePageUrl(int playGuideId) =>
            MakeFullWebViewWebPagePath(SubQuestPlayGuidePagePath + string.Format(SubQuestPlayGuidePageQueryPathFormat, playGuideId));

        private static string MakeWebViewUrl(string basePath, string path)
        {
            var langPath = GetLanguagePath();
            var webViewBase = ApplicationApi.IsReviewEnvironment()
                ? ApplicationApi.GetReviewWebViewBaseUrl()
                : WebViewBaseUrl;

            return webViewBase + basePath + langPath + path;
        }

        private static string GetLanguagePath()
        {
            return PlayerPreference.Instance.CurrentLanguage switch
            {
                10 => EnPagePath,
                17 => KoPagePath,
                _ => JaPagePath,
            };
        }
    }

    public static class Octo
    {
        public static int AppId => IsGlobal ? 301 : 201;

        public static string ClientSecretKey => IsGlobal ? "l488k2zmalogay245osa257ifw2lczq4" : "kgflql1vj1aos2m24v4hxxunuxwla0cm";

        public static string AesKey => IsGlobal ? "st4q3c7p1ibgwdhm" : "p4nohhrnijynw45m";

        public static string Url => IsGlobal ? "https://resources-api.app.nierreincarnation.com/" : "https://resources-api.app.nierreincarnation.jp/";

        private static int OctoPeriod => IsGlobal ? 116830 : 558240;

        private const int OCTO_STAGE = 300000000;
        private const int OCTO_PLATFORM = 2;

        public static int Version => OctoPeriod + OCTO_STAGE + OCTO_PLATFORM;

        public static string A => $"dark_{AppId}_{Version}";
    }
}
