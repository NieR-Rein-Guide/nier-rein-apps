using Art.Framework.ApiNetwork.Grpc.Api.Gimmick;

namespace NierReincarnation.Core.Adam.Framework.Network;

public partial class DarkClient : IGimmickService
{
    public IGimmickService GimmickService => this;

    public Task<UpdateGimmickProgressResponse> UpdateGimmickProgressAsync(UpdateGimmickProgressRequest request)
    {
        const string path = "GimmickService/UpdateGimmickProgressAsync";
        return InvokeAsync<UpdateGimmickProgressResponse, UpdateGimmickProgressRequest>(path, request,
            ctx =>
                new ResponseContext<UpdateGimmickProgressResponse>(new GimmickService.GimmickServiceClient(GetCallInvoker(ctx.Channel)).UpdateGimmickProgressAsync((UpdateGimmickProgressRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }
}
