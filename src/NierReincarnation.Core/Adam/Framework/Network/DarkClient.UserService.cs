using Art.Framework.ApiNetwork.Grpc.Api.User;
using Google.Protobuf.WellKnownTypes;

namespace NierReincarnation.Core.Adam.Framework.Network;

public partial class DarkClient : IUserService
{
    public IUserService UserService => this;

    public Task<RegisterUserResponse> RegisterUserAsync(RegisterUserRequest request)
    {
        return InvokeAsync<RegisterUserResponse, RegisterUserRequest>("UserService/RegisterUserAsync", request,
            ctx => new ResponseContext<RegisterUserResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).RegisterUserAsync((RegisterUserRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<TransferUserResponse> TransferUserAsync(TransferUserRequest request)
    {
        return InvokeAsync<TransferUserResponse, TransferUserRequest>("UserService/TransferUserAsync", request,
            ctx => new ResponseContext<TransferUserResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).TransferUserAsync((TransferUserRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<AuthUserResponse> AuthAsync(AuthUserRequest request)
    {
        return InvokeAsync<AuthUserResponse, AuthUserRequest>("UserService/AuthAsync", request,
            ctx => new ResponseContext<AuthUserResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).AuthAsync((AuthUserRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<GameStartResponse> GameStartAsync(Empty request)
    {
        return InvokeAsync<GameStartResponse, Empty>("UserService/GameStartAsync", request,
            ctx => new ResponseContext<GameStartResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).GameStartAsync((Empty)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<SetUserNameResponse> SetUserNameAsync(SetUserNameRequest request)
    {
        return InvokeAsync<SetUserNameResponse, SetUserNameRequest>("UserService/SetUserNameAsync", request,
            ctx => new ResponseContext<SetUserNameResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).SetUserNameAsync((SetUserNameRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<SetUserMessageResponse> SetUserMessageAsync(SetUserMessageRequest request)
    {
        return InvokeAsync<SetUserMessageResponse, SetUserMessageRequest>("UserService/SetUserMessageAsync", request,
            ctx => new ResponseContext<SetUserMessageResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).SetUserMessageAsync((SetUserMessageRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<SetUserFavoriteCostumeIdResponse> SetUserFavoriteCostumeIdAsync(SetUserFavoriteCostumeIdRequest request)
    {
        return InvokeAsync<SetUserFavoriteCostumeIdResponse, SetUserFavoriteCostumeIdRequest>("UserService/SetUserFavoriteCostumeIdAsync", request,
            ctx => new ResponseContext<SetUserFavoriteCostumeIdResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).SetUserFavoriteCostumeIdAsync((SetUserFavoriteCostumeIdRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<GetUserProfileResponse> GetUserProfileAsync(GetUserProfileRequest request)
    {
        return InvokeAsync<GetUserProfileResponse, GetUserProfileRequest>("UserService/GetUserProfileAsync", request,
            ctx => new ResponseContext<GetUserProfileResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).GetUserProfileAsync((GetUserProfileRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<SetBirthYearMonthResponse> SetBirthYearMonthAsync(SetBirthYearMonthRequest request)
    {
        return InvokeAsync<SetBirthYearMonthResponse, SetBirthYearMonthRequest>("UserService/SetBirthYearMonthAsync", request,
            ctx => new ResponseContext<SetBirthYearMonthResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).SetBirthYearMonthAsync((SetBirthYearMonthRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<GetBirthYearMonthResponse> GetBirthYearMonthAsync(Empty request)
    {
        return InvokeAsync<GetBirthYearMonthResponse, Empty>("UserService/GetBirthYearMonthAsync", request,
            ctx => new ResponseContext<GetBirthYearMonthResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).GetBirthYearMonthAsync((Empty)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<GetChargeMoneyResponse> GetChargeMoneyAsync(Empty request)
    {
        return InvokeAsync<GetChargeMoneyResponse, Empty>("UserService/GetChargeMoneyAsync", request,
            ctx => new ResponseContext<GetChargeMoneyResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).GetChargeMoneyAsync((Empty)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<SetUserSettingResponse> SetUserSettingAsync(SetUserSettingRequest request)
    {
        return InvokeAsync<SetUserSettingResponse, SetUserSettingRequest>("UserService/SetUserSettingAsync", request,
            ctx => new ResponseContext<SetUserSettingResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).SetUserSettingAsync((SetUserSettingRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<GetAndroidArgsResponse> GetAndroidArgsAsync(GetAndroidArgsRequest request)
    {
        return InvokeAsync<GetAndroidArgsResponse, GetAndroidArgsRequest>("UserService/GetAndroidArgsAsync", request,
            ctx => new ResponseContext<GetAndroidArgsResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).GetAndroidArgsAsync((GetAndroidArgsRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<GetBackupTokenResponse> GetBackupTokenAsync(GetBackupTokenRequest request)
    {
        return InvokeAsync<GetBackupTokenResponse, GetBackupTokenRequest>("UserService/GetBackupTokenAsync", request,
            ctx => new ResponseContext<GetBackupTokenResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).GetBackupTokenAsync((GetBackupTokenRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<CheckTransferSettingResponse> CheckTransferSettingAsync(Empty request)
    {
        return InvokeAsync<CheckTransferSettingResponse, Empty>("UserService/CheckTransferSettingAsync", request,
            ctx => new ResponseContext<CheckTransferSettingResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).CheckTransferSettingAsync((Empty)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<SetFacebookAccountResponse> SetFacebookAccountAsync(SetFacebookAccountRequest request)
    {
        return InvokeAsync<SetFacebookAccountResponse, SetFacebookAccountRequest>("UserService/SetFacebookAccountAsync", request,
            ctx => new ResponseContext<SetFacebookAccountResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).SetFacebookAccountAsync((SetFacebookAccountRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<UnsetFacebookAccountResponse> UnsetFacebookAccountAsync(Empty request)
    {
        return InvokeAsync<UnsetFacebookAccountResponse, Empty>("UserService/UnsetFacebookAccountAsync", request,
            ctx => new ResponseContext<UnsetFacebookAccountResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).UnsetFacebookAccountAsync((Empty)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<SetAppleAccountResponse> SetAppleAccountAsync(SetAppleAccountRequest request)
    {
        return InvokeAsync<SetAppleAccountResponse, SetAppleAccountRequest>("UserService/SetAppleAccountAsync", request,
            ctx => new ResponseContext<SetAppleAccountResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).SetAppleAccountAsync((SetAppleAccountRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<TransferUserByFacebookResponse> TransferUserByFacebookAsync(TransferUserByFacebookRequest request)
    {
        return InvokeAsync<TransferUserByFacebookResponse, TransferUserByFacebookRequest>("UserService/TransferUserByFacebookAsync", request,
            ctx => new ResponseContext<TransferUserByFacebookResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).TransferUserByFacebookAsync((TransferUserByFacebookRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<TransferUserByAppleResponse> TransferUserByAppleAsync(TransferUserByAppleRequest request)
    {
        return InvokeAsync<TransferUserByAppleResponse, TransferUserByAppleRequest>("UserService/TransferUserByAppleAsync", request,
            ctx => new ResponseContext<TransferUserByAppleResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).TransferUserByAppleAsync((TransferUserByAppleRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<GetUserGamePlayNoteResponse> GetUserGamePlayNoteAsync(GetUserGamePlayNoteRequest request)
    {
        return InvokeAsync<GetUserGamePlayNoteResponse, GetUserGamePlayNoteRequest>("UserService/GetUserGamePlayNoteAsync", request,
            ctx => new ResponseContext<GetUserGamePlayNoteResponse>(new UserService.UserServiceClient(GetCallInvoker(ctx.Channel)).GetUserGamePlayNoteAsync((GetUserGamePlayNoteRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }
}
