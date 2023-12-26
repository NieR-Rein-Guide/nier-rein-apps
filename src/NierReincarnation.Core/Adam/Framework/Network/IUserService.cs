using Art.Framework.ApiNetwork.Grpc.Api.User;
using Google.Protobuf.WellKnownTypes;

namespace NierReincarnation.Core.Adam.Framework.Network;

public interface IUserService
{
    public abstract Task<RegisterUserResponse> RegisterUserAsync(RegisterUserRequest request);

    public abstract Task<TransferUserResponse> TransferUserAsync(TransferUserRequest request);

    public abstract Task<AuthUserResponse> AuthAsync(AuthUserRequest request);

    public abstract Task<GameStartResponse> GameStartAsync(Empty request);

    public abstract Task<SetUserNameResponse> SetUserNameAsync(SetUserNameRequest request);

    public abstract Task<SetUserMessageResponse> SetUserMessageAsync(SetUserMessageRequest request);

    public abstract Task<SetUserFavoriteCostumeIdResponse> SetUserFavoriteCostumeIdAsync(SetUserFavoriteCostumeIdRequest request);

    public abstract Task<GetUserProfileResponse> GetUserProfileAsync(GetUserProfileRequest request);

    public abstract Task<SetBirthYearMonthResponse> SetBirthYearMonthAsync(SetBirthYearMonthRequest request);

    public abstract Task<GetBirthYearMonthResponse> GetBirthYearMonthAsync(Empty request);

    public abstract Task<GetChargeMoneyResponse> GetChargeMoneyAsync(Empty request);

    public abstract Task<SetUserSettingResponse> SetUserSettingAsync(SetUserSettingRequest request);

    public abstract Task<GetAndroidArgsResponse> GetAndroidArgsAsync(GetAndroidArgsRequest request);

    public abstract Task<GetBackupTokenResponse> GetBackupTokenAsync(GetBackupTokenRequest request);

    public abstract Task<CheckTransferSettingResponse> CheckTransferSettingAsync(Empty request);

    public abstract Task<SetFacebookAccountResponse> SetFacebookAccountAsync(SetFacebookAccountRequest request);

    public abstract Task<UnsetFacebookAccountResponse> UnsetFacebookAccountAsync(Empty request);

    public abstract Task<SetAppleAccountResponse> SetAppleAccountAsync(SetAppleAccountRequest request);

    public abstract Task<TransferUserByFacebookResponse> TransferUserByFacebookAsync(TransferUserByFacebookRequest request);

    public abstract Task<TransferUserByAppleResponse> TransferUserByAppleAsync(TransferUserByAppleRequest request);

    public abstract Task<GetUserGamePlayNoteResponse> GetUserGamePlayNoteAsync(GetUserGamePlayNoteRequest request);
}
