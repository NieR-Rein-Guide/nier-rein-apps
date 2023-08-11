using NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Request;
using NierReincarnation.Core.Custom;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Parameter
{
    // Art.Framework.ApiNetwork.Parameter.Parameter
    sealed class Parameter
    {
        // 0x10
        private readonly UserParameter _userParameter;
        // 0x18
        private readonly AuthParameter _authParameter;
        // 0x20
        private readonly TokenParameter _tokenParameter;
        // 0x28
        private readonly MasterDataVersionParameter _masterDataVersionParameter;
        // 0x30
        private readonly CommonRequest _commonRequest;

        // Properties
        public UserParameter User => _userParameter;
        public AuthParameter Auth => _authParameter;
        public TokenParameter Token => _tokenParameter;
        public MasterDataVersionParameter MasterDataVersion => _masterDataVersionParameter;

        public Parameter()
        {
            _userParameter = new UserParameter();
            _authParameter = new AuthParameter();
            _tokenParameter = new TokenParameter();
            _masterDataVersionParameter = new MasterDataVersionParameter();
            _commonRequest = new CommonRequest
            {
                AppVersion = Application.Version,
                Language = Application.SystemLanguage,
                OsVersion = SystemInfo.OperatingSystem,
                DeviceName = SystemInfo.DeviceName
            };
        }

        public void UpdateSession(string newSessionKey)
        {
            _commonRequest.SessionKey = newSessionKey;
        }
    }
}
