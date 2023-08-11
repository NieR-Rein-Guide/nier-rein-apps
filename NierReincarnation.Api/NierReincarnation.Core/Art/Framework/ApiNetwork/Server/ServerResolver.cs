namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Server
{
    // Art.Framework.ApiNetwork.Server.ServerResolver
    public class ServerResolver
    {
        // 0x10
        public string ServerDomain;
        // 0x18
        private string ReviewDomain;
        // 0x20
        private bool IsReviewServer;

        internal void SetReviewFlag()
        {
            IsReviewServer = true;
        }

        public void SetConfiguration(ServerConfiguration configuration)
        {
            ServerDomain = configuration.Server;
            ReviewDomain = configuration.ReviewServer;
        }
    }
}
