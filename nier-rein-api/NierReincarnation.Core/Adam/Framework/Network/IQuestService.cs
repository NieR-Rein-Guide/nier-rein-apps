using System.Threading.Tasks;
using Art.Framework.ApiNetwork.Grpc.Api.Quest;

namespace NierReincarnation.Core.Adam.Framework.Network
{
    public interface IQuestService
    {
        Task<StartEventQuestResponse> StartEventQuestAsync(StartEventQuestRequest request);

        Task<FinishEventQuestResponse> FinishEventQuestAsync(FinishEventQuestRequest request);

        Task<UpdateEventQuestSceneProgressResponse> UpdateEventQuestSceneProgressAsync(UpdateEventQuestSceneProgressRequest request);
    }
}
