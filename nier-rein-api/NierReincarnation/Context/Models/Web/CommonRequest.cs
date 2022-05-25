using System;
using NierReincarnation.Core.Adam.Framework.Network;
using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Context.Models.Web
{
    class CommonRequest
    {
        public string appVersion { get; set; } = Application.Version;
        public string deviceName { get; set; } = SystemInfo.DeviceName;
        public string language { get; set; } = Application.SystemLanguage;
        public string osType { get; set; } = $"{(int)Application.Platform}";
        public string osVersion { get; set; } = SystemInfo.OperatingSystem;
        public string platformType { get; set; } = $"{(int)Application.Platform}";
        public long requestDatetime { get; set; } = (long) (DateTime.Now - DateTime.UnixEpoch).TotalSeconds;
        public long requestId { get; set; } = 1;
        public string sessionKey { get; set; } = ApplicationScopeClientContext.Instance.Auth.SessionKey;
        public string token { get; set; } = ApplicationScopeClientContext.Instance.Token.Value;
        public string userIdString { get; set; } = $"{ApplicationScopeClientContext.Instance.User.UserId}";
    }
}
