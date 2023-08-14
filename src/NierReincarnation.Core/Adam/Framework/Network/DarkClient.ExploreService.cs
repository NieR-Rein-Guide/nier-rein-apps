using Art.Framework.ApiNetwork.Grpc.Api.Explore;

namespace NierReincarnation.Core.Adam.Framework.Network;

public partial class DarkClient : IExploreService
{
    public IExploreService ExploreService => this;

    public Task<StartExploreResponse> StartExploreAsync(StartExploreRequest request)
    {
        const string path = "ExploreService/StartExploreAsync";
        return InvokeAsync<StartExploreResponse, StartExploreRequest>(path, request,
            ctx =>
                new ResponseContext<StartExploreResponse>(new ExploreService.ExploreServiceClient(GetCallInvoker(ctx.Channel)).StartExploreAsync((StartExploreRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<FinishExploreResponse> FinishExploreAsync(FinishExploreRequest request)
    {
        const string path = "ExploreService/FinishExploreAsync";
        return InvokeAsync<FinishExploreResponse, FinishExploreRequest>(path, request,
            ctx =>
                new ResponseContext<FinishExploreResponse>(new ExploreService.ExploreServiceClient(GetCallInvoker(ctx.Channel)).FinishExploreAsync((FinishExploreRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<RetireExploreResponse> RetireExploreAsync(RetireExploreRequest request)
    {
        const string path = "ExploreService/RetireExploreAsync";
        return InvokeAsync<RetireExploreResponse, RetireExploreRequest>(path, request,
            ctx =>
                new ResponseContext<RetireExploreResponse>(new ExploreService.ExploreServiceClient(GetCallInvoker(ctx.Channel)).RetireExploreAsync((RetireExploreRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }
}
