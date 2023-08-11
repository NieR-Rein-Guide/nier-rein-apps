using NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Request;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Parameter;

public sealed class Parameter
{
    private readonly CommonRequest _commonRequest;

    public UserParameter User { get; }

    public AuthParameter Auth { get; }

    public TokenParameter Token { get; }

    public MasterDataVersionParameter MasterDataVersion { get; }

    public Parameter()
    {
        User = new UserParameter();
        Auth = new AuthParameter();
        Token = new TokenParameter();
        MasterDataVersion = new MasterDataVersionParameter();
        _commonRequest = new CommonRequest
        {
            AppVersion = Application.Version,
            Language = Application.SystemLanguage.ToString(),
            OsVersion = SystemInfo.OperatingSystem,
            DeviceName = SystemInfo.DeviceName
        };
    }

    public void UpdateSession(string newSessionKey)
    {
        _commonRequest.SessionKey = newSessionKey;
    }
}
