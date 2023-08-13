using Art.Framework.ApiNetwork.Grpc.Api.Quest;
using Google.Protobuf.WellKnownTypes;

namespace NierReincarnation.Core.Adam.Framework.Network;

public interface IQuestService
{
    public abstract Task<UpdateMainFlowSceneProgressResponse> UpdateMainFlowSceneProgressAsync(UpdateMainFlowSceneProgressRequest request);

    //public abstract Task<UpdateReplayFlowSceneProgressResponse> UpdateReplayFlowSceneProgressAsync(UpdateReplayFlowSceneProgressRequest request);

    public abstract Task<UpdateMainQuestSceneProgressResponse> UpdateMainQuestSceneProgressAsync(UpdateMainQuestSceneProgressRequest request);

    //public abstract Task<UpdateExtraQuestSceneProgressResponse> UpdateExtraQuestSceneProgressAsync(UpdateExtraQuestSceneProgressRequest request);

    public abstract Task<UpdateEventQuestSceneProgressResponse> UpdateEventQuestSceneProgressAsync(UpdateEventQuestSceneProgressRequest request);

    public abstract Task<StartMainQuestResponse> StartMainQuestAsync(StartMainQuestRequest request);

    //public abstract Task<RestartMainQuestResponse> RestartMainQuestAsync(RestartMainQuestRequest request);

    public abstract Task<FinishMainQuestResponse> FinishMainQuestAsync(FinishMainQuestRequest request);

    public abstract Task<StartExtraQuestResponse> StartExtraQuestAsync(StartExtraQuestRequest request);

    //public abstract Task<RestartExtraQuestResponse> RestartExtraQuestAsync(RestartExtraQuestRequest request);

    public abstract Task<FinishExtraQuestResponse> FinishExtraQuestAsync(FinishExtraQuestRequest request);

    public abstract Task<StartEventQuestResponse> StartEventQuestAsync(StartEventQuestRequest request);

    //public abstract Task<RestartEventQuestResponse> RestartEventQuestAsync(RestartEventQuestRequest request);

    public abstract Task<FinishEventQuestResponse> FinishEventQuestAsync(FinishEventQuestRequest request);

    //public abstract Task<FinishAutoOrbitResponse> FinishAutoOrbitAsync(Empty request);

    //public abstract Task<SetRouteResponse> SetRouteAsync(SetRouteRequest request);

    //public abstract Task<SetQuestSceneChoiceResponse> SetQuestSceneChoiceAsync(SetQuestSceneChoiceRequest request);

    //public abstract Task<ReceiveTowerAccumulationRewardResponse> ReceiveTowerAccumulationRewardAsync(ReceiveTowerAccumulationRewardRequest request);

    //public abstract Task<SkipQuestResponse> SkipQuestAsync(SkipQuestRequest request);

    //public abstract Task<SkipQuestBulkResponse> SkipQuestBulkAsync(SkipQuestBulkRequest request);

    //public abstract Task<SetAutoSaleSettingResponse> SetAutoSaleSettingAsync(SetAutoSaleSettingRequest request);

    //public abstract Task<StartGuerrillaFreeOpenResponse> StartGuerrillaFreeOpenAsync(Empty request);

    //public abstract Task<ResetLimitContentQuestProgressResponse> ResetLimitContentQuestProgressAsync(ResetLimitContentQuestProgressRequest request);

    public abstract Task<ReceiveDailyQuestGroupCompleteRewardResponse> ReceiveDailyQuestGroupCompleteRewardAsync(Empty request);
}
