namespace NierReincarnation.Core.Octo;

public interface ICaching
{
    bool IsReady { get; }

    int ExpirationDelay { set; }

    long MaximumAvailableDiskSpace { set; }

    public abstract bool IsLatestAssetBundleCached(string name);

    public abstract bool IsLatestResourceCached(string name);

    public abstract bool CleanCache();

    public abstract string GetResourceStoragePath(string name);
}
