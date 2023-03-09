using System;
using NierReincarnation.Core.Octo.Caching;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.Octo.Loader;

namespace NierReincarnation.Core.Octo
{
    static class OctoManager
    {
        public static readonly string Version = "2.8.4"; // 0x0
        private static readonly int SaveVersion = 0x20804; // 0x8
        private static readonly string Tag = "Octo/OctoManager"; // 0x10
        //private static ILogger<Logger> k__BackingField; // 0x18
        //private static IAssetBundleLoader AssetBundleLoader; // 0x20
        //private static IResourceLoader ResourceLoader; // 0x28
        //private static IExecutor LoadExecutor; // 0x40
        private static DateTime _dbUpdateTimeAfterStartup; // 0x48
        //private static AssetBundleLoadHandler AssetBundleLoadInterceptor; // 0x60
        //private static AssetBundleUnloadHandler OnAssetBundleUnloadCompleted; // 0x68
        //private static GameObject _octoGameObject; // 0x80
        private static IOctoSettings _settings; // 0x88

        public static ICaching Caching => Internal._caching;
        public static int DbRevision => Internal._dataManager.Revision;
        //public static ILogger Logger { get; set; }
        //public static IAssetBundleLoader AssetBundleLoader { get; set; }
        //public static IResourceLoader ResourceLoader { get; set; }
        // 0x30
        public static IDatabase Database { get; set; }
        // 0x38
        public static IExecutor DownloadExecutor { get; set; }
        //private static IExecutor LoadExecutor { set; }
        // 0x50
        public static bool IsSetupped { get; set; }
        // 0x51
        public static bool AllowDeleted { get; set; }
        //public static DownloadErrorHandler DownloadErrorInteceptor { get; set; }
        //public static AssetBundleLoadHandler AssetBundleLoadInterceptor { get; set; }
        //public static AssetBundleUnloadHandler OnAssetBundleUnloadCompleted { get; set; }
        // 0x70
        public static AssetLoader.LoadPriority AssetLoaderPriority { get; set; }

        public static bool Setup(OctoFullSettings settings, bool reset = false)
        {
            if (!_Setup(settings, reset))
                return false;

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            AssetLoaderPriority = settings.AssetLoaderPriority;
            AllowDeleted = settings.AllowDeleted;

            switch (settings.CachingType)
            {
                case CachingType.OctoFullCache:
                    if (Internal._caching == null)
                        throw new ArgumentNullException(nameof(Internal._caching));

                    Internal._caching.MaximumAvailableDiskSpace = settings.MaximumAvailableDiskSpace;
                    Internal._caching.ExpirationDelay = settings.ExpirationDelay;
                    break;
            }

            return true;
        }

        public static void StartDbUpdate(Action<DownloadError> onComplete, bool reset = false, int dbRevision = 0)
        {
            var revision = reset ? dbRevision : Internal._dataManager.Revision;
            Internal._octoAPI.GetDatabaseDiff(revision, (bytes, error) =>
            {
                if (error == null)
                {
                    _dbUpdateTimeAfterStartup = DateTime.Now;
                    error = Internal._dataManager.ApplyToDatabase(bytes, revision == 0);
                }

                onComplete.TrySafeInvoke(error.ToNamedError(string.Empty));
            });
        }

        private static bool _Setup(IOctoSettings settings, bool reset = false)
        {
            if (!IsSetupped && !reset)
                return false;

            if (settings == null)
            {
                // Log error with message 'Settings not found!'
                throw new ArgumentNullException(nameof(settings));
            }

            IOctoSettings localSettings;
            if (!IsSetupped)
            {
                IsSetupped = true;

                // CUSTOM: Creating instances here, instead of retrieving them from unity
                DownloadExecutor = Internal._downloader = new Downloader();
                // CUSTOM: Ignore LoadExecutor, AssetBundleManager, and Timer

                localSettings = settings;
            }
            else
                localSettings = _settings;

            var args = new object[5];
            args[0] = localSettings.Version.ToString();
            args[1] = localSettings.MaxParallelDownload.ToString();
            args[2] = localSettings.MaxParallelLoad.ToString();
            args[3] = ((int)localSettings.CachingType).ToString();
            args[4] = localSettings.AppId.ToString();
            // Log with message 'Setup {4} with: version={0}, max DL={1}, max Load={2}, caching type={3}' and args

            _settings = localSettings;

            AESCrypt crypt = null;
            if (!string.IsNullOrEmpty(localSettings.AesKey))
                crypt = new AESCrypt(localSettings.AesKey);

            Internal._dataManager = new DataManager(localSettings.AppId, localSettings.Version, crypt);
            VersionChecker.Check(SaveVersion);

            Internal._dataManager.Initialize();
            Database = Internal._dataManager;

            Internal._octoAPI = new OctoAPI(_settings);

            if (Internal._caching == null || _settings.CachingType != localSettings.CachingType)
            {
                switch (_settings.CachingType)
                {
                    case CachingType.UnityDefault:
                        // TODO: Implement caching?
                        //Internal._caching = new UnityCaching();
                        //AssetBundleLoader = new UnityAssetBundleLoader();
                        //ResourceLoader = null;
                        break;

                    default:
                        // TODO: Implement caching?
                        Internal._caching = OctoHybridCaching.WrapIfNeeded(new OctoCaching(_settings, _settings.CachingType == CachingType.OctoAutoDelete));
                        //AssetBundleLoader = new OctoAssetBundleLoader(Internal._caching);
                        //ResourceLoader = new OctoResourceLoader(Internal._caching);
                        break;
                }
            }

            // Set unload handler to Internal+0x30

            return true;
        }

        internal static class Internal
        {
            public static OctoAPI _octoAPI; // 0x0
            public static DataManager _dataManager; // 0x8
            public static Downloader _downloader; // 0x10
            //public static LoadExecutor _loadExecutor; // 0x18
            //public static Timer _timer; // 0x20
            public static ICachingInternal _caching; // 0x28
            //public static AssetBundleManager _assetBundleManager; // 0x30
        }
    }
}
