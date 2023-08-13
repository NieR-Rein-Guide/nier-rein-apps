using Art.Framework.ApiNetwork.Grpc.Api.Config;
using Google.Protobuf.WellKnownTypes;

namespace NierReincarnation.Core.Adam.Framework.Network;

public partial class DarkClient : IConfigService
{
    public IConfigService ConfigService => this;

    public Task<GetReviewServerConfigResponse> GetReviewServerConfigAsync(Empty request)
    {
        const string path = "ConfigService/GetReviewServerConfigAsync";
        return InvokeAsync<GetReviewServerConfigResponse, Empty>(path, request,
            ctx =>
                new ResponseContext<GetReviewServerConfigResponse>(new ConfigService.ConfigServiceClient(GetCallInvoker(ctx.Channel)).GetReviewServerConfigAsync((Empty)ctx.Request, ctx.Headers, ctx.Deadline)));
    }
}
