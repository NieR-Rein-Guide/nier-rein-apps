namespace NierReincarnation.Core.UnityEngine.Purchasing;

public class ProductDefinition
{
    public string id { get; set; }

    public string storeSpecificId { get; set; }

    public ProductType type { get; set; }

    public bool enabled { get; set; }

    public IEnumerable<PayoutDefinition> payouts { get; }
}
