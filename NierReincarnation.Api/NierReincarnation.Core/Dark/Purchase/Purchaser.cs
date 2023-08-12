using NierReincarnation.Core.UnityEngine.Purchasing;

namespace NierReincarnation.Core.Dark.Purchase;

internal class Purchaser : IStoreListener
{
    private ConfigurationBuilder _builder;
    private bool _purchaseOnInitialize;
    private bool _purchased;
    private Action<Product> _processPurchaseCallback;

    public async Task InitializeAndroid(List<string> productIds, Action<Product> processPurchaseCallback, bool enableTimeout = false)
    {
        var purchaseModule = StandardPurchasingModule.Instance;
        _builder = ConfigurationBuilder.Instance(purchaseModule);

        await Initialize(productIds, processPurchaseCallback, enableTimeout);
    }

    private Task Initialize(List<string> productIds, Action<Product> processPurchaseCallback, bool enableTimeout = false)
    {
        productIds.ForEach(productId => _builder.AddProduct(productId, ProductType.Consumable));

        _purchaseOnInitialize = true;
        _purchased = false;
        _processPurchaseCallback = processPurchaseCallback;

        return Task.CompletedTask;
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        if (!_purchaseOnInitialize)
        {
            _purchased = true;
            return PurchaseProcessingResult.Pending;
        }

        _processPurchaseCallback(purchaseEvent.purchasedProduct);
        return PurchaseProcessingResult.Pending;
    }
}
