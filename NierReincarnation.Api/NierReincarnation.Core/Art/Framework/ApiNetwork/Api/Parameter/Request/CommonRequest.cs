namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Request
{
    // Art.Framework.ApiNetwork.Api.Parameter.Request.CommonRequest
    class CommonRequest
    {
        // Fields
        public string appVersion; // 0x10
        public long userId; // 0x18
        public string sessionKey; // 0x20
        public string language; // 0x28
        public int osType; // 0x30
        public string osVersion; // 0x38
        public string deviceName; // 0x40
        public long requestDatetime; // 0x48
        public string token; // 0x50
        public string masterDataHash; // 0x58
        public string requestUuid; // 0x60
    }
}
