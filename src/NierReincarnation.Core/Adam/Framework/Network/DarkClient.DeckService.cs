using Art.Framework.ApiNetwork.Grpc.Api.Deck;

namespace NierReincarnation.Core.Adam.Framework.Network;

public partial class DarkClient : IDeckService
{
    public IDeckService DeckService => this;

    public Task<UpdateNameResponse> UpdateNameAsync(UpdateNameRequest request)
    {
        const string path = "DeckService/UpdateNameAsync";
        return InvokeAsync<UpdateNameResponse, UpdateNameRequest>(path, request,
            ctx =>
                new ResponseContext<UpdateNameResponse>(new DeckService.DeckServiceClient(GetCallInvoker(ctx.Channel)).UpdateNameAsync((UpdateNameRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<ReplaceDeckResponse> ReplaceDeckAsync(ReplaceDeckRequest request)
    {
        const string path = "DeckService/ReplaceDeckAsync";
        return InvokeAsync<ReplaceDeckResponse, ReplaceDeckRequest>(path, request,
            ctx =>
                new ResponseContext<ReplaceDeckResponse>(new DeckService.DeckServiceClient(GetCallInvoker(ctx.Channel)).ReplaceDeckAsync((ReplaceDeckRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }

    public Task<RemoveDeckResponse> RemoveDeckAsync(RemoveDeckRequest request)
    {
        const string path = "DeckService/RemoveDeckAsync";
        return InvokeAsync<RemoveDeckResponse, RemoveDeckRequest>(path, request,
            ctx =>
                new ResponseContext<RemoveDeckResponse>(new DeckService.DeckServiceClient(GetCallInvoker(ctx.Channel)).RemoveDeckAsync((RemoveDeckRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }
}
