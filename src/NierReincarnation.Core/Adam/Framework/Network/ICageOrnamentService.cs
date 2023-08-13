using Art.Framework.ApiNetwork.Grpc.Api.CageOrnament;

namespace NierReincarnation.Core.Adam.Framework.Network;

public interface ICageOrnamentService
{
    public abstract Task<ReceiveRewardResponse> ReceiveRewardAsync(ReceiveRewardRequest request);

    //public abstract Task<RecordAccessResponse> RecordAccessAsync(RecordAccessRequest request);
}
