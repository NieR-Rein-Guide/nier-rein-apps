using NierReincarnation.Core.Art.Framework.ApiNetwork.Mediator.Model;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Server;
using NierReincarnation.Core.Dark.Networking;
using NierReincarnation.Core.Dark.Preference;

namespace NierReincarnation.Core.Adam.Framework.Network;

public sealed class ApplicationScopeClientContext
{
    public static readonly ApplicationScopeClientContext Instance = new();

    public ServerResolver ServerResolver { get; }

    public TokenInfo Token { get; }

    public AuthInfo Auth { get; set; }

    public UserInfo User { get; set; }

    public AppTrackingStatus AppTrackingTransparencyStatus { get; set; }

    public MasterDataVersionInfo MasterData { get; set; }

    private ApplicationScopeClientContext()
    {
        ServerResolver = new ServerResolver();
        Token = new TokenInfo();
        Auth = new AuthInfo(ContextPreference.Instance);
        MasterData = new MasterDataVersionInfo(ContextPreference.Instance);
        AppTrackingTransparencyStatus = AppTrackingStatus.Unsupported;
    }
}

public sealed class TokenInfo
{
    private string token;

    public string Value => token;

    public void UpdateToken(string token)
    {
        this.token = token;
    }
}

public sealed class AuthInfo
{
    private readonly ContextPreference _context;

    private string _sessionKey;

    private long _sessionExpire;

    public string SessionKey => _sessionKey;

    public AuthInfo(ContextPreference context)
    {
        _context = context;
        _sessionKey = context.SessionKey;
        _sessionExpire = context.SessionExpire;
    }

    public void UpdateSession(UserAuthData authData)
    {
        _context.SessionKey = _sessionKey = authData.SessionKey;
        _context.SessionExpire = _sessionExpire = authData.ExpireDatetime;
    }
}

public sealed class UserInfo
{
    private readonly PlayerRegistration _registration;

    public string Signature { get; private set; }

    public string Uuid { get; set; }

    public string TerminalId { get; }

    public string AdvertisingId { get; private set; }

    public bool IsTrackingEnabled { get; private set; }

    public long UserId { get; set; }

    public UserInfo(PlayerRegistration registration)
    {
        _registration = registration;
        UserId = registration.UserId;
        Signature = registration.Signature;
        Uuid = registration.Uuid;
        TerminalId = registration.TerminalId;
        AdvertisingId = registration.AdvertisingId;
        IsTrackingEnabled = registration.IsTrackingEnabled;
    }

    public void SetUserData(UserRegisterData registerData)
    {
        UserId = registerData.UserId;
        Signature = registerData.Signature;
        Uuid = registerData.UuId;
    }

    public void UpdateSignature(string signature)
    {
        Signature = signature;
    }

    public void UpdateAdvertisingId(string adId, bool trackingEnabled)
    {
        AdvertisingId = adId;
        IsTrackingEnabled = trackingEnabled;
    }
}

public sealed class MasterDataVersionInfo
{
    private readonly ContextPreference _context;

    public int MasterDataVersion { get; private set; }

    public string MasterDataHash { get; private set; }

    public MasterDataVersionInfo(ContextPreference context)
    {
        _context = context;
        MasterDataVersion = context.MasterDataVersion;
        MasterDataHash = string.Empty;
    }

    public void UpdateMasterDataVersion(int version)
    {
        MasterDataVersion = version;
        _context.MasterDataVersion = version;
    }

    public void UpdateMasterDataHash(string hash)
    {
        MasterDataHash = hash;
    }
}
