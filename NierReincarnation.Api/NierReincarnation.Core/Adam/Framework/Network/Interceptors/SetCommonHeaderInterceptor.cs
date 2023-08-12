using Grpc.Core;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Adam.Framework.Network.Interceptors;

public class SetCommonHeaderInterceptor : INetworkInterceptor
{
    private readonly string _appVersion;
    private readonly string _language;
    private readonly string _osVersion;
    private readonly string _deviceName;
    private readonly Random _rand = new();
    private long _prevRequestId;

    private const string kAppVersionHeader = "x-apb-app-version";
    private const string kLanguageHeader = "x-apb-language";
    private const string kOsVersionHeader = "x-apb-os-version";
    private const string kDeviceNameHeader = "x-apb-device-name";
    private const string kOsTypeHeader = "x-apb-os-type";
    private const string kPlatformTypeHeader = "x-apb-platform-type";
    private const string kRequestDateTimeHeader = "x-apb-request-datetime";
    private const string kRequestIdHeader = "x-apb-request-id";
    private const string kMacAddressHeader = "x-apb-mac-addr";
    private const string kUserIdHeader = "x-apb-user-id";
    private const string kSessionKeyHeader = "x-apb-session-key";
    private const string kTokenHeader = "x-apb-token";
    private const string kMasterDataHashHeader = "x-apb-master-data-hash";
    private const string kAdjustIdHeader = "x-adjust-id";
    private const string kDeviceIdHeader = "x-apb-device-id";
    private const string kAdvertisingIdHeader = "x-apb-advertising-id";
    private const string kKeyChainUserIdHeader = "x-apb-keychain-user-id";
    private const string kEditorAdjustId = "UnityEditor";
    private const string kKeyChainUserId = "user_id";

    private const string kOsTypeiOS = "1";
    private const string kOsTypeAndroid = "2";
    private const string kPlatformAppStore = "1";
    private const string kPlatformGooglePlayStore = "2";
    private const string kPlatformAmazon = "8";

    public SetCommonHeaderInterceptor()
    {
        _appVersion ??= Application.Version;
        _language ??= Application.SystemLanguage.ToString();
        _osVersion ??= SystemInfo.OperatingSystem;
        _deviceName ??= SystemInfo.DeviceModel;
    }

    public Task<ResponseContext> SendAsync(RequestContext context, Func<RequestContext, Task<ResponseContext>> next)
    {
        SetCommonHeader(context.Headers);
        return next.Invoke(context);
    }

    private void SetCommonHeader(Metadata headers)
    {
        headers.Add(kAppVersionHeader, _appVersion);
        headers.Add(kLanguageHeader, _language);
        headers.Add(kOsVersionHeader, _osVersion);
        headers.Add(kDeviceNameHeader, _deviceName);
        headers.Add(kDeviceIdHeader, SystemInfo.DeviceUniqueIdentifier);

        if (Application.Platform != PlatformType.APP_STORE)
        {
            headers.Add(kOsTypeHeader, kOsTypeAndroid);

            if (Application.Platform == PlatformType.GOOGLE_PLAY_STORE)
            {
                headers.Add(kPlatformTypeHeader, kPlatformGooglePlayStore);
            }
            else if (Application.Platform == PlatformType.AMAZON_APP_STORE)
            {
                headers.Add(kPlatformTypeHeader, kPlatformAmazon);
            }
        }
        else
        {
            headers.Add(kOsTypeHeader, kOsTypeiOS);
            headers.Add(kPlatformTypeHeader, kPlatformAppStore);
        }

        headers.Add(kRequestDateTimeHeader, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString());

        _prevRequestId = ErrorHandlingInterceptor.IsRetrying ? _prevRequestId : GetRandomLongValue();
        headers.Add(kRequestIdHeader, _prevRequestId.ToString());

        if (ApplicationScopeClientContext.Instance.User is not null)
        {
            headers.Add(kUserIdHeader, ApplicationScopeClientContext.Instance.User.UserId.ToString());
            headers.Add(kAdvertisingIdHeader, ApplicationScopeClientContext.Instance.User.AdvertisingId ?? string.Empty);
        }

        if (ApplicationScopeClientContext.Instance.Auth is not null)
        {
            headers.Add(kSessionKeyHeader, ApplicationScopeClientContext.Instance.Auth.SessionKey ?? string.Empty);
        }

        if (ApplicationScopeClientContext.Instance.Token is not null)
        {
            headers.Add(kTokenHeader, ApplicationScopeClientContext.Instance.Token.Value ?? string.Empty);
        }

        if (ApplicationScopeClientContext.Instance.MasterData is not null)
        {
            headers.Add(kMasterDataHashHeader, ApplicationScopeClientContext.Instance.MasterData.MasterDataHash ?? string.Empty);
        }

        headers.Add(kAdjustIdHeader, string.Empty);
        headers.Add(kKeyChainUserIdHeader, string.Empty);
    }

    private long GetRandomLongValue() => _rand.Next();
}
