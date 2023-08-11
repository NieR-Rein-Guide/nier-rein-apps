using NierReincarnation.Core.Art.Framework.ApiNetwork.Data;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Mediator.Model;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter;

// Art.Framework.ApiNetwork.Parameter.AuthParameter
class AuthParameter : ParameterBase
{
    private string _sessionKey;
    private long _sessionExpire;

    public AuthParameter()
    {
        _sessionKey = ApiSystem.Instance.DataStore.Get(Key.SessionKey);
        var sessionExpire = ApiSystem.Instance.DataStore.Get(Key.SessionExpire);
        if (!string.IsNullOrEmpty(sessionExpire))
            _sessionExpire = long.Parse(sessionExpire);
    }

    public void UpdateSession(UserAuthData authData)
    {
        _sessionKey = authData.SessionKey;
        _sessionExpire = authData.ExpireDatetime;

        ApiSystem.Instance.DataStore.Set(Key.SessionKey, authData.SessionKey);
        ApiSystem.Instance.DataStore.Set(Key.SessionExpire, authData.ExpireDatetime);
    }
}
