using Art.Framework.ApiNetwork.Grpc.Api.Config;

namespace NierReincarnation.Core.Dark.Component.OctoInfo
{
    // Dark.Component.OctoInfo.OctoInfo
    public sealed class OctoInfo
    {
       
        public bool IsReviewEnvironment { get; set; }
       
        public int AppId { get; set; }
       
        public int Version { get; set; }
       
        public string ClientSecretKey { get; set; }
       
        public string AesKey { get; set; }
       
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
