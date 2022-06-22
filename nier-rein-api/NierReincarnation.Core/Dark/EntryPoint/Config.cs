using NierReincarnation.Core.Dark.Kernel;
using NierReincarnation.Core.Dark.Preference;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Dark.EntryPoint
{
    // Dark.Entrypoint.Config
    static class Config
    {
        // CUSTOM: Added En and JP in same config. Use UnityEngine.Application.Language to select correct values
        public static class Api
        {
            // 0x08
            public static readonly string HostnameEn = "api.app.nierreincarnation.com";
            public static readonly string HostnameJp = "api.app.nierreincarnation.jp";
            // 0x10
            public static readonly int Port = 443;
            // 0x18
            public static readonly string WebViewBaseUrlEn = "https://web.app.nierreincarnation.com";
            public static readonly string WebViewBaseUrlJp = "https://web.app.nierreincarnation.jp";
            // 0x20
            public static readonly string MasterDataUrlFormatEn = "https://web.app.nierreincarnation.com/assets/release/{0}/database.bin";
            public static readonly string MasterDataUrlFormatJp = "https://web.app.nierreincarnation.jp/assets/release/{0}/database.bin";
            // 0x38
            public static readonly string EncryptionMasterDataUrlSuffix = ".e";
            // 0x80
            public static readonly string WebPagePath = "/web";
            // 0x98
            public static readonly string InformationPagePath = "/information/?";
            // 0x100
            public static readonly string JaPagePath = "/ja";
            // 0x108
            public static readonly string EnPagePath = "/en";
            // 0x110
            public static readonly string KoPagePath = "/ko";

            /// <summary>
            /// Creates the URL to retrieve the master data from.
            /// </summary>
            /// <param name="masterVersion">The version of the masterdata to retrieve.</param>
            /// <returns>The URL to retrieve masterdata from.</returns>
            public static string MakeMasterDataUrl(string masterVersion)
            {
                var urlFormat = ApplicationApi.IsReviewEnvironment()
                    ? ApplicationApi.GetReviewUrlFormat()
                    : Application.Language == Language.English ? MasterDataUrlFormatEn : MasterDataUrlFormatJp;

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
                    : Application.Language == Language.English ? WebViewBaseUrlEn : WebViewBaseUrlJp;

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
            public static readonly int AppId = 301; // 0x0
            public static readonly string ClientSecretKey = "l488k2zmalogay245osa257ifw2lczq4"; // 0x8
            public static readonly string AesKey = "st4q3c7p1ibgwdhm"; // 0x10
            public static readonly string Url = "https://resources-api.app.nierreincarnation.com/"; // 0x18
            private static readonly int OctoPeriod = 0x1C85E; // 0x20
            private static readonly int OCTO_STAGE = 300000000; // 0x24
            private static readonly int OCTO_PLATFORM = 2; // 0x28
            public static readonly int Version = OctoPeriod + OCTO_STAGE + OCTO_PLATFORM; // 0x2C
            public static readonly string A = $"dark_{AppId}_{Version}"; // 0x30
        }
    }
}
