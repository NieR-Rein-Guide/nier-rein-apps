using Art.Framework.ApiNetwork.Grpc.Api.Battle;

namespace NierReincarnation.Core.Adam.Framework.Network;

public interface IBattleService
{
    public abstract Task<StartWaveResponse> StartWaveAsync(StartWaveRequest request);

    public abstract Task<FinishWaveResponse> FinishWaveAsync(FinishWaveRequest request);
}
