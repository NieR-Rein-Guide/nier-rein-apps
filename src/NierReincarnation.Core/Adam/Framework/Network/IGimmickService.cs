using Art.Framework.ApiNetwork.Grpc.Api.Gimmick;

namespace NierReincarnation.Core.Adam.Framework.Network;

public interface IGimmickService
{
    //public abstract Task<UpdateSequenceResponse> UpdateSequenceAsync(UpdateSequenceRequest request);

    public abstract Task<UpdateGimmickProgressResponse> UpdateGimmickProgressAsync(UpdateGimmickProgressRequest request);

    //public abstract Task<InitSequenceScheduleResponse> InitSequenceScheduleAsync(Empty request);

    //public abstract Task<UnlockResponse> UnlockAsync(UnlockRequest request);
}
