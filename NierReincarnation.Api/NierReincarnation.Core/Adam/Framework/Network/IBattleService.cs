using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.Battle;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    public interface IBattleService
    {
        public Task<StartWaveResponse> StartWaveAsync(StartWaveRequest request);
        public Task<FinishWaveResponse> FinishWaveAsync(FinishWaveRequest request);
    }
}
