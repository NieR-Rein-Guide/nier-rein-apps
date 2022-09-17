using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.Quest;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    public interface IQuestService
    {
        Task<StartEventQuestResponse> StartEventQuestAsync(StartEventQuestRequest request);

        Task<FinishEventQuestResponse> FinishEventQuestAsync(FinishEventQuestRequest request);

        Task<StartMainQuestResponse> StartMainQuestAsync(StartMainQuestRequest request);

        Task<FinishMainQuestResponse> FinishMainQuestAsync(FinishMainQuestRequest request);

        Task<StartExtraQuestResponse> StartExtraQuestAsync(StartExtraQuestRequest request);

        Task<FinishExtraQuestResponse> FinishExtraQuestAsync(FinishExtraQuestRequest request);

        Task<UpdateEventQuestSceneProgressResponse> UpdateEventQuestSceneProgressAsync(UpdateEventQuestSceneProgressRequest request);

        Task<UpdateMainQuestSceneProgressResponse> UpdateMainQuestSceneProgressAsync(UpdateMainQuestSceneProgressRequest request);

        Task<UpdateMainFlowSceneProgressResponse> UpdateMainFlowSceneProgressAsync(UpdateMainFlowSceneProgressRequest request);
    }
}
