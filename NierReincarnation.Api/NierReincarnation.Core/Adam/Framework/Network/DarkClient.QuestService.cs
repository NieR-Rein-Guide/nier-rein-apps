using Art.Framework.ApiNetwork.Grpc.Api.Quest;
using Google.Protobuf.WellKnownTypes;

namespace NierReincarnation.Core.Adam.Framework.Network;

public partial class DarkClient : IQuestService
{
    public IQuestService QuestService => this;

    public Task<StartEventQuestResponse> StartEventQuestAsync(StartEventQuestRequest request)
    {
        const string path = "QuestService/StartEventQuestAsync";
        return InvokeAsync<StartEventQuestResponse, StartEventQuestRequest>(path, request,
            ctx =>
                new ResponseContext<StartEventQuestResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).StartEventQuestAsync((StartEventQuestRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<FinishEventQuestResponse> FinishEventQuestAsync(FinishEventQuestRequest request)
    {
        const string path = "QuestService/FinishEventQuestAsync";
        return InvokeAsync<FinishEventQuestResponse, FinishEventQuestRequest>(path, request,
            ctx =>
                new ResponseContext<FinishEventQuestResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).FinishEventQuestAsync((FinishEventQuestRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<StartMainQuestResponse> StartMainQuestAsync(StartMainQuestRequest request)
    {
        const string path = "QuestService/StartMainQuestAsync";
        return InvokeAsync<StartMainQuestResponse, StartMainQuestRequest>(path, request,
            ctx =>
                new ResponseContext<StartMainQuestResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).StartMainQuestAsync((StartMainQuestRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<FinishMainQuestResponse> FinishMainQuestAsync(FinishMainQuestRequest request)
    {
        const string path = "QuestService/FinishMainQuestAsync";
        return InvokeAsync<FinishMainQuestResponse, FinishMainQuestRequest>(path, request,
            ctx =>
                new ResponseContext<FinishMainQuestResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).FinishMainQuestAsync((FinishMainQuestRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<StartExtraQuestResponse> StartExtraQuestAsync(StartExtraQuestRequest request)
    {
        const string path = "QuestService/StartExtraQuestAsync";
        return InvokeAsync<StartExtraQuestResponse, StartExtraQuestRequest>(path, request,
            ctx =>
                new ResponseContext<StartExtraQuestResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).StartExtraQuestAsync((StartExtraQuestRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<FinishExtraQuestResponse> FinishExtraQuestAsync(FinishExtraQuestRequest request)
    {
        const string path = "QuestService/FinishExtraQuestAsync";
        return InvokeAsync<FinishExtraQuestResponse, FinishExtraQuestRequest>(path, request,
            ctx =>
                new ResponseContext<FinishExtraQuestResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).FinishExtraQuestAsync((FinishExtraQuestRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<UpdateEventQuestSceneProgressResponse> UpdateEventQuestSceneProgressAsync(UpdateEventQuestSceneProgressRequest request)
    {
        const string path = "QuestService/UpdateEventQuestSceneProgressAsync";
        return InvokeAsync<UpdateEventQuestSceneProgressResponse, UpdateEventQuestSceneProgressRequest>(path, request,
            ctx =>
                new ResponseContext<UpdateEventQuestSceneProgressResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).UpdateEventQuestSceneProgressAsync((UpdateEventQuestSceneProgressRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<UpdateMainQuestSceneProgressResponse> UpdateMainQuestSceneProgressAsync(UpdateMainQuestSceneProgressRequest request)
    {
        const string path = "QuestService/UpdateMainQuestSceneProgressAsync";
        return InvokeAsync<UpdateMainQuestSceneProgressResponse, UpdateMainQuestSceneProgressRequest>(path, request,
            ctx =>
                new ResponseContext<UpdateMainQuestSceneProgressResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).UpdateMainQuestSceneProgressAsync((UpdateMainQuestSceneProgressRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<UpdateMainFlowSceneProgressResponse> UpdateMainFlowSceneProgressAsync(UpdateMainFlowSceneProgressRequest request)
    {
        const string path = "QuestService/UpdateMainFlowSceneProgressAsync";
        return InvokeAsync<UpdateMainFlowSceneProgressResponse, UpdateMainFlowSceneProgressRequest>(path, request,
            ctx =>
                new ResponseContext<UpdateMainFlowSceneProgressResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).UpdateMainFlowSceneProgressAsync((UpdateMainFlowSceneProgressRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<ReceiveDailyQuestGroupCompleteRewardResponse> ReceiveDailyQuestGroupCompleteRewardAsync(Empty request)
    {
        const string path = "QuestService/ReceiveDailyQuestGroupCompleteRewardAsync";
        return InvokeAsync<ReceiveDailyQuestGroupCompleteRewardResponse, Empty>(path, request,
            ctx =>
                new ResponseContext<ReceiveDailyQuestGroupCompleteRewardResponse>(new QuestService.QuestServiceClient(GetCallInvoker(ctx.Channel)).ReceiveDailyQuestGroupCompleteRewardAsync((Empty)ctx.Request, ctx.Headers, ctx.Deadline)));
    }
}
