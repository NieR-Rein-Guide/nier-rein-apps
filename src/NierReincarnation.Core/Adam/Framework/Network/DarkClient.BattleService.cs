using Art.Framework.ApiNetwork.Grpc.Api.Battle;

namespace NierReincarnation.Core.Adam.Framework.Network;

public partial class DarkClient : IBattleService
{
    public IBattleService BattleService => this;

    public Task<StartWaveResponse> StartWaveAsync(StartWaveRequest request)
    {
        const string path = "BattleService/StartWaveAsync";
        return InvokeAsync<StartWaveResponse, StartWaveRequest>(path, request,
            ctx =>
                new ResponseContext<StartWaveResponse>(new BattleService.BattleServiceClient(GetCallInvoker(ctx.Channel)).StartWaveAsync((StartWaveRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<FinishWaveResponse> FinishWaveAsync(FinishWaveRequest request)
    {
        const string path = "BattleService/FinishWaveAsync";
        return InvokeAsync<FinishWaveResponse, FinishWaveRequest>(path, request,
            ctx =>
                new ResponseContext<FinishWaveResponse>(new BattleService.BattleServiceClient(GetCallInvoker(ctx.Channel)).FinishWaveAsync((FinishWaveRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }
}
