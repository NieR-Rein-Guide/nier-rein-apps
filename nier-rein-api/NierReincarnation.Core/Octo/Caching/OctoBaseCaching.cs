using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using NierReincarnation.Core.Octo.Util;

namespace NierReincarnation.Core.Octo.Caching
{
    class OctoBaseCaching
    {
        // Stubbed for compilation

        private static readonly string Tag; // 0x0

        private Action OnWarmupCompleted; // 0x10
        private TimeSpan _expirationDelay; // 0x18
        private long _maximumAvailableDiskSpace; // 0x20
        private long _spaceOccupied; // 0x28
        //protected Dictionary<string, Storage> _storageDictionary; // 0x30
        //private StorageList _sortStorageList; // 0x38
        private string _saveDirectory; // 0x40
        private string _downloadDirectory; // 0x48
        private bool _isAutoDelete; // 0x50
        private bool _isConstructing; // 0x51
        private bool _needToRetrieve; // 0x52
        private List<DirectoryInfo> _initialDirectories; // 0x58
        private ManualResetEvent _initialDirectoriesGetCompletedEvent; // 0x60
        //private CacheDeleteExecutor _deleteExecutor; // 0x68
        private ManualResetEvent _warmupThreadWaitEvent; // 0x70
        private bool _isNeededToPauseWarmup; // 0x78
        //protected WarmupState _warmupState; // 0x79
        private object _storageModifyMutex; // 0x80
        private object _initialDirectoriesMutex; // 0x88

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
}
