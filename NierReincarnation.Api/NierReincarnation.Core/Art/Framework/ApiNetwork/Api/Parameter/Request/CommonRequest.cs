namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Api.Parameter.Request
{
    // Art.Framework.ApiNetwork.Api.Parameter.Request.CommonRequest
    class CommonRequest
    {
        // Fields
        public string AppVersion; // 0x10
        public long UserId; // 0x18
        public string SessionKey; // 0x20
        public string Language; // 0x28
        public int OsType; // 0x30
        public string OsVersion; // 0x38
        public string DeviceName; // 0x40
        public long RequestDatetime; // 0x48
        public string Token; // 0x50
        public string MasterDataHash; // 0x58
        public string RequestUuid; // 0x60
    }
}
