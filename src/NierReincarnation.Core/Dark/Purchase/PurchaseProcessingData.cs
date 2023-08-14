using NierReincarnation.Core.UnityEngine.Purchasing;

namespace NierReincarnation.Core.Dark.Purchase;

public class PurchaseProcessingData
{
    public string BridgeTransactionId { get; set; }

    public Product Product { get; }

    public PurchaseProcessingData(Product product)
    {
        BridgeTransactionId = string.Empty;
        Product = product;
    }
}
