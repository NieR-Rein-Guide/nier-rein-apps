using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.User;
using Google.Protobuf.WellKnownTypes;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    public interface IUserService
    {
        Task<AuthUserResponse> AuthAsync(AuthUserRequest request);
        Task<GetAndroidArgsResponse> GetAndroidArgsAsync(GetAndroidArgsRequest request);
        Task<GetBackupTokenResponse> GetBackupTokenAsync(GetBackupTokenRequest request);
        Task<TransferUserResponse> TransferUserAsync(TransferUserRequest request);

        Task<GetChargeMoneyResponse> GetChargeMoneyAsync(Empty request);
    }
}
