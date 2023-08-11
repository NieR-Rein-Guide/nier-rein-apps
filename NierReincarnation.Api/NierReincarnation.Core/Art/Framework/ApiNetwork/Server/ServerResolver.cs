namespace NierReincarnation.Core.Art.Framework.ApiNetwork.Server;

public class ServerResolver
{
    public string ServerDomain;
    private string ReviewDomain;
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
