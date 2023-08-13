using Art.Framework.ApiNetwork.Grpc.Api.ConsumableItem;

namespace NierReincarnation.Core.Adam.Framework.Network;

public partial class DarkClient : IConsumableItemService
{
    public IConsumableItemService ConsumableItemService => this;

    public Task<UseEffectItemResponse> UseEffectItemAsync(UseEffectItemRequest request)
    {
        const string path = "ConsumableItemService/UseEffectItemAsync";
        return InvokeAsync<UseEffectItemResponse, UseEffectItemRequest>(path, request,
            ctx =>
                new ResponseContext<UseEffectItemResponse>(new ConsumableItemService.ConsumableItemServiceClient(GetCallInvoker(ctx.Channel)).UseEffectItemAsync((UseEffectItemRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }
}
