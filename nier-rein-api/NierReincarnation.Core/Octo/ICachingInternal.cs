using NierReincarnation.Core.Octo.Data;

namespace NierReincarnation.Core.Octo
{
    interface ICachingInternal : ICaching
    {
        bool IsLatestAssetBundleCached(Item data);

        bool IsLatestResourceCached(Item data);

        bool UnlockAssetBundle(Item data);
    }
}
