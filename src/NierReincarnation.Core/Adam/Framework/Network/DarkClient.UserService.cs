using Art.Framework.ApiNetwork.Grpc.Api.User;
using Google.Protobuf.WellKnownTypes;

namespace NierReincarnation.Core.Adam.Framework.Network;

public partial class DarkClient : IUserService
{
    public IUserService UserService => this;

    public Task<AuthUserResponse> AuthAsync(AuthUserRequest request)
    {
        const string path = "UserService/AuthAsync";
        return InvokeAsync<AuthUserResponse, AuthUserRequest>(path, request,
            ctx =>
                new ResponseContext<AuthUserResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).AuthAsync((AuthUserRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<GetAndroidArgsResponse> GetAndroidArgsAsync(GetAndroidArgsRequest request)
    {
        const string path = "UserService/GetAndroidArgsAsync";
        return InvokeAsync<GetAndroidArgsResponse, GetAndroidArgsRequest>(path, request,
            ctx =>
                new ResponseContext<GetAndroidArgsResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).GetAndroidArgsAsync((GetAndroidArgsRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<GetBackupTokenResponse> GetBackupTokenAsync(GetBackupTokenRequest request)
    {
        const string path = "UserService/GetBackupTokenAsync";
        return InvokeAsync<GetBackupTokenResponse, GetBackupTokenRequest>(path, request,
            ctx =>
                new ResponseContext<GetBackupTokenResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).GetBackupTokenAsync((GetBackupTokenRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<TransferUserResponse> TransferUserAsync(TransferUserRequest request)
    {
        const string path = "UserService/TransferUserAsync";
        return InvokeAsync<TransferUserResponse, TransferUserRequest>(path, request,
            ctx =>
                new ResponseContext<TransferUserResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).TransferUserAsync((TransferUserRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<GetChargeMoneyResponse> GetChargeMoneyAsync(Empty request)
    {
        const string path = "UserService/GetChargeMoneyAsync";
        return InvokeAsync<GetChargeMoneyResponse, Empty>(path, request,
            ctx =>
                new ResponseContext<GetChargeMoneyResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).GetChargeMoneyAsync((Empty)ctx.Request, ctx.Headers, ctx.Deadline)));
    }
}
