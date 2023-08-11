using Art.Framework.ApiNetwork.Grpc.Api.BigHunt;

namespace NierReincarnation.Core.Adam.Framework.Network;

public partial class DarkClient : IBigHuntService
{
    public IBigHuntService BigHuntService => this;

    public Task<StartBigHuntQuestResponse> StartBigHuntQuestAsync(StartBigHuntQuestRequest request)
    {
        const string path = "BigHuntService/StartBigHuntQuestAsync";
        return InvokeAsync<StartBigHuntQuestResponse, StartBigHuntQuestRequest>(path, request,
            ctx =>
                new ResponseContext<StartBigHuntQuestResponse>(new BigHuntService.BigHuntServiceClient(GetCallInvoker(ctx.Channel)).StartBigHuntQuestAsync((StartBigHuntQuestRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<FinishBigHuntQuestResponse> FinishBigHuntQuestAsync(FinishBigHuntQuestRequest request)
    {
        const string path = "BigHuntService/FinishBigHuntQuestAsync";
        return InvokeAsync<FinishBigHuntQuestResponse, FinishBigHuntQuestRequest>(path, request,
            ctx =>
                new ResponseContext<FinishBigHuntQuestResponse>(new BigHuntService.BigHuntServiceClient(GetCallInvoker(ctx.Channel)).FinishBigHuntQuestAsync((FinishBigHuntQuestRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<SaveBigHuntBattleInfoResponse> SaveBigHuntBattleInfoAsync(SaveBigHuntBattleInfoRequest request)
    {
        const string path = "BigHuntService/StartBigHuntQuestAsync";
        return InvokeAsync<SaveBigHuntBattleInfoResponse, SaveBigHuntBattleInfoRequest>(path, request,
            ctx =>
                new ResponseContext<SaveBigHuntBattleInfoResponse>(new BigHuntService.BigHuntServiceClient(GetCallInvoker(ctx.Channel)).SaveBigHuntBattleInfoAsync((SaveBigHuntBattleInfoRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }
}
