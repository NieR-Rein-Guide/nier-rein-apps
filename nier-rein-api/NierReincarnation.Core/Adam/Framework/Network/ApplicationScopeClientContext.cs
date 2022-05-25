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
            // 0x10
            private string token;

            public string Value => token;

            public void UpdateToken(string token)
            {
                this.token = token;
            }
        }

        public sealed class AuthInfo
        {
            // 0x10
            private readonly ContextPreference _context;
            // 0x18
            private string _sessionKey;
            // 0x20
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
            // 0x10
            private readonly PlayerRegistration _registration;
            // 0x20
            private string _uuid;
            // 0x40
            private long _userId;

            // 0x18
            public string Signature { get; private set; }

            public string Uuid
            {
                get => _uuid;
                set => _uuid = value;
            }

            // 0x28
            public string TerminalId { get; private set; }
            // 0x30
            public string AdvertisingId { get; private set; }
            // 0x38
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
            // 0x10
            private readonly ContextPreference _context;

            // 0x18
            public int MasterDataVersion { get; private set; }

            // 0x20
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

        // 0x00
        public static readonly ApplicationScopeClientContext Instance = new ApplicationScopeClientContext();

        // 0x10
        public ServerResolver ServerResolver { get; private set; }

        // 0x18
        public TokenInfo Token { get; private set; }

        // 0x20
        public AuthInfo Auth { get; set; }

        // 0x28
        public UserInfo User { get; set; }

        // 0x30
        public AppTrackingStatus AppTrackingTransparencyStatus { get; set; }

        // 0x38
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
