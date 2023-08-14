using Art.Framework.ApiNetwork.Grpc.Api.CageOrnament;

namespace NierReincarnation.Core.Adam.Framework.Network;

public partial class DarkClient : ICageOrnamentService
{
    public ICageOrnamentService CageOrnamentService => this;

    public Task<ReceiveRewardResponse> ReceiveRewardAsync(ReceiveRewardRequest request)
    {
        const string path = "CageOrnamentService/ReceiveRewardAsync";
        return InvokeAsync<ReceiveRewardResponse, ReceiveRewardRequest>(path, request,
            ctx =>
                new ResponseContext<ReceiveRewardResponse>(new CageOrnamentService.CageOrnamentServiceClient(GetCallInvoker(ctx.Channel)).ReceiveRewardAsync((ReceiveRewardRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }
}
