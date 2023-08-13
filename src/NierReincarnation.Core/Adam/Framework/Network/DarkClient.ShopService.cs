using Art.Framework.ApiNetwork.Grpc.Api.Shop;

namespace NierReincarnation.Core.Adam.Framework.Network;

public partial class DarkClient : IShopService
{
    public IShopService ShopService => this;

    public Task<CreatePurchaseTransactionResponse> CreatePurchaseTransactionAsync(CreatePurchaseTransactionRequest request)
    {
        const string path = "ShopService/CreatePurchaseTransactionAsync";
        return InvokeAsync<CreatePurchaseTransactionResponse, CreatePurchaseTransactionRequest>(path, request,
            ctx =>
                new ResponseContext<CreatePurchaseTransactionResponse>(new ShopService.ShopServiceClient(GetCallInvoker(ctx.Channel)).CreatePurchaseTransactionAsync((CreatePurchaseTransactionRequest)ctx.Request, ctx.Headers, ctx.Deadline)));
    }
}
