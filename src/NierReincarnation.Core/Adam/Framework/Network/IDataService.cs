using Art.Framework.ApiNetwork.Grpc.Api.Data;
using Google.Protobuf.WellKnownTypes;

namespace NierReincarnation.Core.Adam.Framework.Network;

public interface IDataService
{
    public abstract Task<MasterDataGetLatestVersionResponse> GetLatestMasterDataVersionAsync(Empty request);

    public abstract Task<UserDataGetNameResponse> GetUserDataNameAsync(Empty request);

    public abstract Task<UserDataGetNameResponseV2> GetUserDataNameV2Async(Empty request);

    public abstract Task<UserDataGetResponse> GetUserDataAsync(UserDataGetRequest request);
}
