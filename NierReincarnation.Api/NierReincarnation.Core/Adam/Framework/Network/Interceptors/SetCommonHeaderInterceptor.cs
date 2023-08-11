using System;
using System.Threading.Tasks;
using Grpc.Core;
using NierReincarnation.Core.Custom;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Adam.Framework.Network.Interceptors
{
    // Adam.Framework.Network.Interceptors.SetCommonHeaderInterceptor
    class SetCommonHeaderInterceptor : INetworkInterceptor
    {
        // 0x10 onwards
        private string appVersion;
        private string language;
        private string osVersion;
        private string deviceName;
        private Random rand = new Random(); // 0x30
        private long prevRequestId;

        // static 0x00 onwards
        private static readonly string kAppVersionHeader = "x-apb-app-version";
        private static readonly string kLanguageHeader = "x-apb-language";
        private static readonly string kOsVersionHeader = "x-apb-os-version";
        private static readonly string kDeviceNameHeader = "x-apb-device-name";
        private static readonly string kOsTypeHeader = "x-apb-os-type";
        private static readonly string kPlatformTypeHeader = "x-apb-platform-type";
        private static readonly string kRequestDateTimeHeader = "x-apb-request-datetime";
        private static readonly string kRequestIdHeader = "x-apb-request-id";
        private static readonly string kMacAddressHeader = "x-apb-mac-addr";
        private static readonly string kUserIdHeader = "x-apb-user-id";
        private static readonly string kSessionKeyHeader = "x-apb-session-key";
        private static readonly string kTokenHeader = "x-apb-token";
        private static readonly string kMasterDataHashHeader = "x-apb-master-data-hash";
        private static readonly string kAdjustIdHeader = "x-adjust-id";
        private static readonly string kDeviceIdHeader = "x-apb-device-id";
        private static readonly string kAdvertisingIdHeader = "x-apb-advertising-id";
        private static readonly string kKeyChainUserIdHeader = "x-apb-keychain-user-id";
        private static readonly string kEditorAdjustId = "UnityEditor";
        private static readonly string kKeyChainUserId = "user_id";
        // 0x98 onwards
        private static readonly string kOsTypeiOS = "1";
        private static readonly string kOsTypeAndroid = "2";
        private static readonly string kPlatformAppStore = "1";
        private static readonly string kPlatformGooglePlayStore = "2";
        private static readonly string kPlatformAmazon = "8";

        public Task<ResponseContext> SendAsync(RequestContext context, Func<RequestContext, Task<ResponseContext>> next)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            SetCommonHeader(context.Headers);

            return next?.Invoke(context);
        }

        private void SetCommonHeader(Metadata headers)
        {
            // At least required headers:
            // - kAppVersionHeader
            // - kUserIdHeader

            headers.Add(kAppVersionHeader, appVersion ??= Application.Version);
            headers.Add(kLanguageHeader, language ??= Application.SystemLanguage.ToString());
            headers.Add(kOsVersionHeader, osVersion ??= SystemInfo.OperatingSystem);
            headers.Add(kDeviceNameHeader, deviceName ??= SystemInfo.DeviceName);

            if (Application.Platform == PlatformType.AMAZON_APP_STORE)
            {
                headers.Add(kOsTypeHeader, kOsTypeiOS);
                headers.Add(kPlatformTypeHeader, kPlatformAppStore);
            }
            else
            {
                headers.Add(kOsTypeHeader, kOsTypeAndroid);
                headers.Add(kPlatformTypeHeader, kPlatformGooglePlayStore);
            }

            headers.Add(kRequestDateTimeHeader, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString());

            prevRequestId = ErrorHandlingInterceptor.IsRetrying ? prevRequestId : GetRandomLongValue();
            headers.Add(kRequestIdHeader, prevRequestId.ToString());

            var userInfo = ApplicationScopeClientContext.Instance?.User;
            var authInfo = ApplicationScopeClientContext.Instance?.Auth;
            var tokenInfo = ApplicationScopeClientContext.Instance?.Token;
            var masterData = ApplicationScopeClientContext.Instance?.MasterData;

            if (userInfo != null)
            {
                headers.Add(kUserIdHeader, userInfo.UserId.ToString());

                headers.Add(kAdvertisingIdHeader, userInfo.AdvertisingId ?? string.Empty);
                headers.Add(kKeyChainUserIdHeader, SystemInformation.Instance.KeyChainUserId ?? string.Empty);
            }
            if (authInfo != null)
                headers.Add(kSessionKeyHeader, authInfo.SessionKey ?? string.Empty);
            if (tokenInfo != null)
                headers.Add(kTokenHeader, tokenInfo.Value ?? string.Empty);
            if (masterData != null)
                headers.Add(kMasterDataHashHeader, masterData.MasterDataHash ?? string.Empty);

            headers.Add(kAdjustIdHeader, SystemInformation.Instance.AdjustId ?? string.Empty);
            headers.Add(kDeviceIdHeader, SystemInfo.DeviceUniqueIdentifier ?? string.Empty);
        }

        private long GetRandomLongValue()
        {
            return rand.Next();
        }
    }
}
