using System;
using NierReincarnation.Core.Octo.Data;

namespace NierReincarnation.Core.Octo.Caching
{
    class OctoHybridCaching : IOctoCaching
    {
        private static readonly string Tag;

        private IOctoCaching _caching;
        private OctoAppCaching _appCaching;

       
        public OctoCaching StorageCaching { get; set; }

        public bool IsReady { get; }
        public int ExpirationDelay { get; set; }
        public long MaximumAvailableDiskSpace { get; set; }

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

        public static IOctoCaching WrapIfNeeded(IOctoCaching caching)
        {
            if (OctoAppCaching.HasInAppCache())
                return caching;

            return new OctoHybridCaching
            {
                StorageCaching = caching.StorageCaching, 
                _caching = caching.StorageCaching
            };

        }
    }
}
