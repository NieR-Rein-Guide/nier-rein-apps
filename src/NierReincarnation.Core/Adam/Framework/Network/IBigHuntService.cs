using Art.Framework.ApiNetwork.Grpc.Api.BigHunt;

namespace NierReincarnation.Core.Adam.Framework.Network;

public interface IBigHuntService
{
    public abstract Task<StartBigHuntQuestResponse> StartBigHuntQuestAsync(StartBigHuntQuestRequest request);

    //public abstract Task<UpdateBigHuntQuestSceneProgressResponse> UpdateBigHuntQuestSceneProgressAsync(UpdateBigHuntQuestSceneProgressRequest request);

    public abstract Task<FinishBigHuntQuestResponse> FinishBigHuntQuestAsync(FinishBigHuntQuestRequest request);

    //public abstract Task<RestartBigHuntQuestResponse> RestartBigHuntQuestAsync(RestartBigHuntQuestRequest request);

    //public abstract Task<SkipBigHuntQuestResponse> SkipBigHuntQuestAsync(SkipBigHuntQuestRequest request);

    public abstract Task<SaveBigHuntBattleInfoResponse> SaveBigHuntBattleInfoAsync(SaveBigHuntBattleInfoRequest request);

    //public abstract Task<GetBigHuntTopDataResponse> GetBigHuntTopDataAsync(Empty request);
}
