using NierReincarnation.Core.Dark.Kernel;
using NierReincarnation.Core.Dark.Preference;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Dark.EntryPoint;

// Dark.Entrypoint.Config
internal static class Config
{
    // CUSTOM: Added En and JP in same config. Use UnityEngine.Application.Language to select correct values
    public static class Api
    {
        public static readonly string HostnameEn = "api.app.nierreincarnation.com";
        public static readonly string HostnameJp = "api.app.nierreincarnation.jp";

        public static readonly int Port = 443;

        public static readonly string WebViewBaseUrlEn = "https://web.app.nierreincarnation.com";
        public static readonly string WebViewBaseUrlJp = "https://web.app.nierreincarnation.jp";

        public static readonly string MasterDataUrlFormatEn = "https://web.app.nierreincarnation.com/assets/release/{0}/database.bin";
        public static readonly string MasterDataUrlFormatJp = "https://web.app.nierreincarnation.jp/assets/release/{0}/database.bin";

        public static readonly string EncryptionMasterDataUrlSuffix = ".e";

        public static readonly string WebPagePath = "/web";

        public static readonly string InformationPagePath = "/information/?";

        public static readonly string JaPagePath = "/ja";

        public static readonly string EnPagePath = "/en";

        public static readonly string KoPagePath = "/ko";

        // CUSTOM
        public static readonly string NotificationGetUrlEn = "https://api-web.app.nierreincarnation.com/api/information/list/get";

        public static readonly string NotificationGetUrlJp = "https://api-web.app.nierreincarnation.jp/api/information/list/get";

        public static readonly string NotificationDetailUrlEn = "https://api-web.app.nierreincarnation.com/api/information/detail/get";
        public static readonly string NotificationDetailUrlJp = "https://api-web.app.nierreincarnation.jp/api/information/detail/get";

        // CUSTOM: Get hostname based on language identifier
        public static string GetHostname()
        {
            return Application.SystemLanguage == SystemLanguage.English ? HostnameEn : HostnameJp;
        }

        // CUSTOM: Get notification list url
        public static string GetNotificationGetUrl()
        {
            return Application.SystemLanguage == SystemLanguage.English ? NotificationGetUrlEn : NotificationGetUrlJp;
        }

        // CUSTOM: Get notification detail url
        public static string GetNotificationDetailUrl()
        {
            return Application.SystemLanguage == SystemLanguage.English ? NotificationDetailUrlEn : NotificationDetailUrlJp;
        }

        /// <summary>
        /// Creates the URL to retrieve the master data from.
        /// </summary>
        /// <param name="masterVersion">The version of the masterdata to retrieve.</param>
        /// <returns>The URL to retrieve masterdata from.</returns>
        public static string MakeMasterDataUrl(string masterVersion)
        {
            var urlFormat = ApplicationApi.IsReviewEnvironment()
                ? ApplicationApi.GetReviewUrlFormat()
                : Application.SystemLanguage == SystemLanguage.English ? MasterDataUrlFormatEn : MasterDataUrlFormatJp;

            return string.Format(urlFormat, masterVersion) + EncryptionMasterDataUrlSuffix;
        }

        /// <summary>
        /// Creates the URL to retrieve any webview from.
        /// </summary>
        /// <param name="path">The path to a webview.</param>
        /// <returns>The full URL to a web view without query parameters.</returns>
        public static string MakeFullWebViewWebPagePath(string path)
        {
            return MakeWebViewUrl(WebPagePath, path);
        }

        /// <summary>
        /// Creates the URL to retrieve any notification from.
        /// </summary>
        /// <returns></returns>
        public static string MakeWebViewInformationPageUrl()
        {
            return MakeWebViewUrl(string.Empty, InformationPagePath);
        }

        public static string MakeWebViewInformationPageUrl(int informationId)
        {
            return MakeWebViewUrl(string.Empty, $"{InformationPagePath}informationId={informationId}");
        }

        private static string MakeWebViewUrl(string basePath, string path)
        {
            var langPath = GetLanguagePath();
            var webViewBase = ApplicationApi.IsReviewEnvironment()
                ? ApplicationApi.GetReviewWebViewBaseUrl()
                : Application.SystemLanguage == SystemLanguage.English ? WebViewBaseUrlEn : WebViewBaseUrlJp;

            return $"{webViewBase}{basePath}{langPath}{path}";
        }

        private static string GetLanguagePath()
        {
            switch (PlayerPreference.Instance.CurrentLanguage)
            {
                case 10:
                    return EnPagePath;

                case 17:
                    return KoPagePath;

                default:
                    return JaPagePath;
            }
        }
    }

    public static class Octo
    {
        public static readonly int AppId = 301;
        public static readonly string ClientSecretKey = "l488k2zmalogay245osa257ifw2lczq4";
        public static readonly string AesKey = "st4q3c7p1ibgwdhm";
        public static readonly string Url = "https://resources-api.app.nierreincarnation.com/";
        private static readonly int OctoPeriod = 0x1C85E;
        private static readonly int OCTO_STAGE = 300000000;
        private static readonly int OCTO_PLATFORM = 2;
        public static readonly int Version = OctoPeriod + OCTO_STAGE + OCTO_PLATFORM;
        public static readonly string A = $"dark_{AppId}_{Version}";
    }
}
