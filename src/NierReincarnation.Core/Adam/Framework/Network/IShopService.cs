using Art.Framework.ApiNetwork.Grpc.Api.Shop;

namespace NierReincarnation.Core.Adam.Framework.Network;

public interface IShopService
{
    //public abstract Task<BuyResponse> BuyAsync(BuyRequest request);

    //public abstract Task<RefreshResponse> RefreshUserDataAsync(RefreshRequest request);

    //public abstract Task<GetCesaLimitResponse> GetCesaLimitAsync(Empty request);

    public abstract Task<CreatePurchaseTransactionResponse> CreatePurchaseTransactionAsync(CreatePurchaseTransactionRequest request);

    //public abstract Task<PurchaseGooglePlayStoreProductResponse> PurchaseGooglePlayStoreProductAsync(PurchaseGooglePlayStoreProductRequest request);
}
