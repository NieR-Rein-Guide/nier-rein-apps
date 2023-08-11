using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using NierReincarnation.Core.Octo.Util;

namespace NierReincarnation.Core.Octo.Caching;

class OctoBaseCaching
{
    // Stubbed for compilation

    private static readonly string Tag;

    private Action OnWarmupCompleted;
    private TimeSpan _expirationDelay;
    private long _maximumAvailableDiskSpace;
    private long _spaceOccupied;
    //protected Dictionary<string, Storage> _storageDictionary;
    //private StorageList _sortStorageList;
    private string _saveDirectory;
    private string _downloadDirectory;
    private bool _isAutoDelete;
    private bool _isConstructing;
    private bool _needToRetrieve;
    private List<DirectoryInfo> _initialDirectories;
    private ManualResetEvent _initialDirectoriesGetCompletedEvent;
    //private CacheDeleteExecutor _deleteExecutor;
    private ManualResetEvent _warmupThreadWaitEvent;
    private bool _isNeededToPauseWarmup;
    //protected WarmupState _warmupState;
    private object _storageModifyMutex;
    private object _initialDirectoriesMutex;

    public OctoBaseCaching(IOctoSettings settings, bool isAutoDelete) :
        this(isAutoDelete, FileUtil.UnsafePathCombine("v1", settings.AppId.ToString()), "d", "t")
    {
    }

    public OctoBaseCaching(bool isAutoDelete, string saveDirectory, string downloadDirectory,
        string deleteDirectory)
    {
        _expirationDelay = TimeSpan.Zero;
        _maximumAvailableDiskSpace = 0x40000000;
        //_storageDictionary = new Dictionary<string, Storage>(10000);
        //_sortStorageList = new StorageList(10000);
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
