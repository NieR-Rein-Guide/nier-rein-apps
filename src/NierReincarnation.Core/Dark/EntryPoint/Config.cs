using NierReincarnation.Core.Dark.Kernel;
using NierReincarnation.Core.Dark.Preference;

namespace NierReincarnation.Core.Dark.EntryPoint;

public static class Config
{
    public static class Api
    {
        private const string MasterDataDevUrlFormat = "https://dev-web.dark.abot.sh/assets/release/{0}/database.bin";
        public static readonly string Hostname = "api.app.nierreincarnation.com";
        public static readonly int Port = 443;
        public static readonly string WebViewBaseUrl = "https://web.app.nierreincarnation.com";
        public static string MasterDataUrlFormat = "https://web.app.nierreincarnation.com/assets/release/{0}/database.bin";
        public static readonly string Salt = "qxDjPftFRGc4aGpHtwZajxzV";
        public static readonly int BridgeGameId = 288;
        public static readonly string EncryptionMasterDataUrlSuffix = ".e";
        public static readonly string AccountRegisterUrl = "https://psg.sqex-bridge.jp/ntv/{gameId}/reg/top?type={deviceType}&token={bridgeBackupToken}";
        public static readonly string AccountTransferUrl = "https://psg.sqex-bridge.jp/ntv/{gameId}/update/top?type={deviceType}&token={bridgeBackupToken}";
        public static int BridgeTypeId = 2;
        public static readonly string AmazonStoreURL = "amzn://apps/android?p=com.square_enix.android_amazon.nierspjp";
        public static readonly string GoogleStoreUrl = "https://play.google.com/store/apps/details?id=com.square_enix.android_googleplay.nierspww";
        public static readonly string ItunesStoreUrl = "https://apps.apple.com/us/app/nier-re-in-carnation/id1506553488?mt=8";
        public static readonly string SNSUrl = "https://twitter.com/NieRReinEN";
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
        public static readonly string NotificationGetUrl = "https://api-web.app.nierreincarnation.com/api/information/list/get";
        public static readonly string NotificationDetailUrl = "https://api-web.app.nierreincarnation.com/api/information/detail/get";

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
        public static readonly int AppId = 301;
        public static readonly string ClientSecretKey = "l488k2zmalogay245osa257ifw2lczq4";
        public static readonly string AesKey = "st4q3c7p1ibgwdhm";
        public static readonly string Url = "https://resources-api.app.nierreincarnation.com/";
        private const int OctoPeriod = 116830;
        private const int OCTO_STAGE = 300000000;
        private const int OCTO_PLATFORM = 2;
        public static readonly int Version = OctoPeriod + OCTO_STAGE + OCTO_PLATFORM;
        public static readonly string A = $"dark_{AppId}_{Version}";
    }
}
