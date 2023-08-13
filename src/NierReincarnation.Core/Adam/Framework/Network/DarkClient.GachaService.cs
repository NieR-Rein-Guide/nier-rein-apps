using Art.Framework.ApiNetwork.Grpc.Api.Gacha;

namespace NierReincarnation.Core.Adam.Framework.Network;

public partial class DarkClient : IGachaService
{
    public IGachaService GachaService => this;

    public Task<GetGachaListResponse> GetGachaListAsync(GetGachaListRequest request)
    {
        const string path = "GachaService/GetGachaListAsync";
        return InvokeAsync<GetGachaListResponse, GetGachaListRequest>(path, request,
            ctx =>
                new ResponseContext<GetGachaListResponse>(new GachaService.GachaServiceClient(GetCallInvoker(ctx.Channel)).GetGachaListAsync((GetGachaListRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<GetGachaResponse> GetGachaAsync(GetGachaRequest request)
    {
        const string path = "GachaService/GetGachaAsync";
        return InvokeAsync<GetGachaResponse, GetGachaRequest>(path, request,
            ctx =>
                new ResponseContext<GetGachaResponse>(new GachaService.GachaServiceClient(GetCallInvoker(ctx.Channel)).GetGachaAsync((GetGachaRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }
}
