using NierReincarnation.Core.UnityEngine.Purchasing.Extension;

namespace NierReincarnation.Core.UnityEngine.Purchasing;

public class ConfigurationBuilder
{
    // STUB
    private ConfigurationBuilder(PurchasingFactory factory)
    {
    }

    public static ConfigurationBuilder Instance(IPurchasingModule first, params IPurchasingModule[] rest)
    {
        return new ConfigurationBuilder(new PurchasingFactory(first, rest));
    }

    public ConfigurationBuilder AddProduct(string id, ProductType type)
    {
        return this;
    }
}
