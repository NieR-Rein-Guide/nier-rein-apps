using NierReincarnation.Core.Octo.Caching;
using NierReincarnation.Core.Octo.Data;

namespace NierReincarnation.Core.Octo;

internal interface IOctoCaching : ICachingInternal
{
    OctoCaching StorageCaching { get; }

    bool IsInApp(string bucket, Item item);

    CacheState IsCached(string bucket, string fileName, Item item);

    string GetFilePath(string bucket, string fileName, Item item);
}
