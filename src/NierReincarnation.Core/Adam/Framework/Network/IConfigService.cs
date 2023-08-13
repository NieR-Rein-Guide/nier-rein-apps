using Art.Framework.ApiNetwork.Grpc.Api.Config;
using Google.Protobuf.WellKnownTypes;

namespace NierReincarnation.Core.Adam.Framework.Network;

public interface IConfigService
{
    public abstract Task<GetReviewServerConfigResponse> GetReviewServerConfigAsync(Empty request);
}
