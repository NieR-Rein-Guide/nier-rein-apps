using System;
using NierReincarnation.Core.UnityEngine.Purchasing.Extension;

namespace NierReincarnation.Core.UnityEngine.Purchasing
{
    class StandardPurchasingModule : IPurchasingModule
    {
        private static readonly Lazy<StandardPurchasingModule> Lazy = new Lazy<StandardPurchasingModule>(() => new StandardPurchasingModule());
        public static StandardPurchasingModule Instance => Lazy.Value;

        public void Configure(IPurchasingBinder binder)
        {
            
        }
    }
}
