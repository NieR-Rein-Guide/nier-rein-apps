using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.BigHunt;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    public interface IBigHuntService
    {
        Task<StartBigHuntQuestResponse> StartBigHuntQuestAsync(StartBigHuntQuestRequest request);

        Task<FinishBigHuntQuestResponse> FinishBigHuntQuestAsync(FinishBigHuntQuestRequest request);

        Task<SaveBigHuntBattleInfoResponse> SaveBigHuntBattleInfoAsync(SaveBigHuntBattleInfoRequest request);
    }
}
