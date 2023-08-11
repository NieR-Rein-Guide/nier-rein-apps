using System;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Mediator.Model;
using NierReincarnation.Core.Art.Framework.ApiNetwork.Server;
using NierReincarnation.Core.Dark.Preference;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    // Adam.Framework.Network.ApplicationScopeClientContext
    class ApplicationScopeClientContext
    {
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
           
            private string _uuid;
           
            private long _userId;

           
            public string Signature { get; private set; }

            public string Uuid
            {
                get => _uuid;
                set => _uuid = value;
            }

           
            public string TerminalId { get; private set; }
           
            public string AdvertisingId { get; private set; }
           
            public bool IsTrackingEnabled { get; private set; }
            public long UserId
            {
                get => _userId;
                set => _userId = value;
            }

            public UserInfo(PlayerRegistration registration)
            {
                _registration = registration;
                _userId = registration.UserId;
                Signature = registration.Signature;
                _uuid = registration.Uuid;
                TerminalId = registration.TerminalId;
                AdvertisingId = registration.AdvertisingId;
                IsTrackingEnabled = registration.IsTrackingEnabled;
            }

            public void SetUserData(UserRegisterData registerData)
            {
                _userId = registerData.UserId;
                Signature = registerData.Signature;
                _uuid = registerData.UuId;
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

       
        public static readonly ApplicationScopeClientContext Instance = new ApplicationScopeClientContext();

       
        public ServerResolver ServerResolver { get; private set; }

       
        public TokenInfo Token { get; private set; }

       
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
        }
    }

    public enum AppTrackingStatus
    {
        Unsupported = -1,
        NotDetermined,
        Restricted,
        Denied,
        Authorized
    }
}
