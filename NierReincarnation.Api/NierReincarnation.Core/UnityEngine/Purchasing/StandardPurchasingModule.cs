using NierReincarnation.Core.UnityEngine.Purchasing.Extension;

namespace NierReincarnation.Core.UnityEngine.Purchasing;

public class StandardPurchasingModule : IPurchasingModule
{
    private static readonly Lazy<StandardPurchasingModule> Lazy = new(() => new StandardPurchasingModule());

    public static StandardPurchasingModule Instance => Lazy.Value;

    public void Configure(IPurchasingBinder binder)
    {
    }
}
