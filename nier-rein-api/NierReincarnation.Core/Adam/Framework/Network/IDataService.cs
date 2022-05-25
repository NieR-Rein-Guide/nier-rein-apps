using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.Data;
using Google.Protobuf.WellKnownTypes;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    public interface IDataService
    {
        Task<MasterDataGetLatestVersionResponse> GetLatestMasterDataVersionAsync(Empty request);

        Task<UserDataGetNameResponse> GetUserDataNameAsync(Empty request);

        Task<UserDataGetResponse> GetUserDataAsync(UserDataGetRequest request);
	}
}
