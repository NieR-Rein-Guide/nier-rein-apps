using NierReincarnation.Core.UnityEngine.Purchasing;

namespace NierReincarnation.Core.Dark.Purchase
{
    class PurchaseProcessingData
    {
        // 0x10
        public string BridgeTransactionId { get; set; }
        // 0x18
        public Product Product { get; }

        public PurchaseProcessingData(Product product)
        {
            BridgeTransactionId = string.Empty;
            Product = product;
        }
    }
}
