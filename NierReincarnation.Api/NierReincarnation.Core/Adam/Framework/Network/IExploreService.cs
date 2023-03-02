using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.Explore;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    interface IExploreService
    {
        Task<StartExploreResponse> StartExploreAsync(StartExploreRequest request);

        Task<FinishExploreResponse> FinishExploreAsync(FinishExploreRequest request);

        Task<RetireExploreResponse> RetireExploreAsync(RetireExploreRequest request);
	}
}
