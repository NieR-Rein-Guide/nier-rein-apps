using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NierReincarnation.Core.UnityEngine.Purchasing;

namespace NierReincarnation.Core.Dark.Purchase
{
    class Purchaser: IStoreListener
    {
        private ConfigurationBuilder _builder; // 0x30
        private bool _purchaseOnInitialize; // 0x39
        private bool _purchased; // 0x40
        private Action<Product> _processPurchaseCallback; // 0x48

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
}
