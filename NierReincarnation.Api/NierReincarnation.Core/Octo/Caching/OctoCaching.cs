using System;
using NierReincarnation.Core.Octo.Data;

namespace NierReincarnation.Core.Octo.Caching
{
    class OctoCaching : OctoBaseCaching, IOctoCaching
    {
        // Stubbed for compilation

        public bool IsReady { get; }
        public int ExpirationDelay { get; set; }
        public long MaximumAvailableDiskSpace { get; set; }

        public OctoCaching(IOctoSettings settings, bool isAutoDelete) : base(settings, isAutoDelete)
        {
        }

        public bool IsLatestAssetBundleCached(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsLatestResourceCached(string name)
        {
            throw new NotImplementedException();
        }

        public bool CleanCache()
        {
            throw new NotImplementedException();
        }

        public string GetResourceStoragePath(string name)
        {
            throw new NotImplementedException();
        }

        public bool IsLatestAssetBundleCached(Item data)
        {
            throw new NotImplementedException();
        }

        public bool IsLatestResourceCached(Item data)
        {
            throw new NotImplementedException();
        }

        public bool UnlockAssetBundle(Item data)
        {
            throw new NotImplementedException();
        }

        public OctoCaching StorageCaching { get; }
        public bool IsInApp(string bucket, Item item)
        {
            throw new NotImplementedException();
        }

        public CacheState IsCached(string bucket, string fileName, Item item)
        {
            throw new NotImplementedException();
        }

        public string GetFilePath(string bucket, string fileName, Item item)
        {
            throw new NotImplementedException();
        }
    }
}
