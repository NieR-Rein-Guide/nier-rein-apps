using Art.Framework.ApiNetwork.Grpc.Api.Config;

namespace NierReincarnation.Core.Dark.Component.OctoInfo
{
    // Dark.Component.OctoInfo.OctoInfo
    public sealed class OctoInfo
    {
        // 0x10
        public bool IsReviewEnvironment { get; set; }
        // 0x14
        public int AppId { get; set; }
        // 0x18
        public int Version { get; set; }
        // 0x20
        public string ClientSecretKey { get; set; }
        // 0x28
        public string AesKey { get; set; }
        // 0x30
        public string Url { get; set; }

        public void SetupReviewEnvironment(OctoConfig config)
        {
            IsReviewEnvironment = true;
            AppId = config.AppId;
            Version = config.Version;
            ClientSecretKey = config.ClientSecretKey;
            AesKey = config.AesKey;
            Url = config.Url;
        }
	}
}
