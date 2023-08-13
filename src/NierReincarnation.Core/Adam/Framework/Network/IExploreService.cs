using Art.Framework.ApiNetwork.Grpc.Api.Explore;

namespace NierReincarnation.Core.Adam.Framework.Network;

public interface IExploreService
{
    public abstract Task<StartExploreResponse> StartExploreAsync(StartExploreRequest request);

    public abstract Task<FinishExploreResponse> FinishExploreAsync(FinishExploreRequest request);

    public abstract Task<RetireExploreResponse> RetireExploreAsync(RetireExploreRequest request);
}
