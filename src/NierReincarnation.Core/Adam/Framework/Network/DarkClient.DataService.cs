using Art.Framework.ApiNetwork.Grpc.Api.Data;
using Google.Protobuf.WellKnownTypes;

namespace NierReincarnation.Core.Adam.Framework.Network;

public partial class DarkClient : IDataService
{
    public IDataService DataService => this;

    public Task<MasterDataGetLatestVersionResponse> GetLatestMasterDataVersionAsync(Empty request)
    {
        const string path = "DataService/GetLatestMasterDataVersionAsync";
        return InvokeAsync<MasterDataGetLatestVersionResponse, Empty>(path, request,
            ctx =>
                new ResponseContext<MasterDataGetLatestVersionResponse>(new DataService.DataServiceClient(GetCallInvoker(ctx.Channel)).GetLatestMasterDataVersionAsync((Empty)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<UserDataGetNameResponse> GetUserDataNameAsync(Empty request)
    {
        var path = "DataService/GetUserDataNameAsync";
        return InvokeAsync<UserDataGetNameResponse, Empty>(path, request,
            ctx =>
                new ResponseContext<UserDataGetNameResponse>(new DataService.DataServiceClient(GetCallInvoker(ctx.Channel)).GetUserDataNameAsync((Empty)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<UserDataGetResponse> GetUserDataAsync(UserDataGetRequest request)
    {
        const string path = "DataService/GetUserDataAsync";
        return InvokeAsync<UserDataGetResponse, UserDataGetRequest>(path, request,
            ctx =>
                new ResponseContext<UserDataGetResponse>(new DataService.DataServiceClient(GetCallInvoker(ctx.Channel)).GetUserDataAsync((UserDataGetRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }
}
