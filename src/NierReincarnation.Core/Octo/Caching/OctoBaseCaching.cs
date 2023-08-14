using NierReincarnation.Core.Octo.Util;

namespace NierReincarnation.Core.Octo.Caching;

internal class OctoBaseCaching
{
    private static readonly string Tag;

    private readonly Action OnWarmupCompleted;
    private readonly TimeSpan _expirationDelay;
    private readonly long _maximumAvailableDiskSpace;
    private readonly long _spaceOccupied;
    private readonly string _saveDirectory;
    private readonly string _downloadDirectory;
    private readonly bool _isAutoDelete;
    private readonly bool _isConstructing;
    private readonly bool _needToRetrieve;
    private readonly List<DirectoryInfo> _initialDirectories;
    private readonly ManualResetEvent _initialDirectoriesGetCompletedEvent;
    private readonly ManualResetEvent _warmupThreadWaitEvent;
    private readonly bool _isNeededToPauseWarmup;
    private readonly object _storageModifyMutex;
    private readonly object _initialDirectoriesMutex;

    public OctoBaseCaching(IOctoSettings settings, bool isAutoDelete) :
        this(isAutoDelete, FileUtil.UnsafePathCombine("v1", settings.AppId.ToString()), "d", "t")
    {
    }

    public OctoBaseCaching(bool isAutoDelete, string saveDirectory, string downloadDirectory,
        string deleteDirectory)
    {
        _expirationDelay = TimeSpan.Zero;
        _maximumAvailableDiskSpace = 0x40000000;
        _isConstructing = true;
        _initialDirectoriesGetCompletedEvent = new ManualResetEvent(false);
        _storageModifyMutex = new object();
        _initialDirectoriesMutex = new object();

        _isAutoDelete = isAutoDelete;
        _saveDirectory = FileUtil.UnsafePathCombine(FileUtil.GetCachePath(), saveDirectory);
        _downloadDirectory = FileUtil.UnsafePathCombine(FileUtil.GetCachePath(), downloadDirectory);

        if (!isAutoDelete)
        {
            _expirationDelay = TimeSpan.Zero;
            _maximumAvailableDiskSpace = 0;
        }

        PrepareDirectory(deleteDirectory);
        _warmupThreadWaitEvent = new ManualResetEvent(true);

        ThreadPool.QueueUserWorkItem(WarmupThread);
    }

    private void PrepareDirectory(string deleteDirectory)
    {
        // TODO: Implement, if necessary
    }

    private void WarmupThread(object state)
    {
        // TODO: Implement, if necessary
    }
}
