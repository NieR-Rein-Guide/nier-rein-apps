using NierReincarnation.Core.Octo.Caching;
using NierReincarnation.Core.Octo.Data;
using NierReincarnation.Core.Octo.Loader;

namespace NierReincarnation.Core.Octo;

public static class OctoManager
{
    public static readonly string Version = "2.8.4";
    private const int SaveVersion = 0x20804;
    private const string Tag = "Octo/OctoManager";

    //private static ILogger<Logger> k__BackingField;
    //private static IAssetBundleLoader AssetBundleLoader;
    //private static IResourceLoader ResourceLoader;
    //private static IExecutor LoadExecutor;
    private static DateTime _dbUpdateTimeAfterStartup;

    //private static AssetBundleLoadHandler AssetBundleLoadInterceptor;
    //private static AssetBundleUnloadHandler OnAssetBundleUnloadCompleted;
    //private static GameObject _octoGameObject;
    private static IOctoSettings _settings;

    public static ICaching Caching => Internal._caching;

    public static int DbRevision => Internal._dataManager.Revision;

    public static DataManager DataManager => Internal._dataManager;

    //public static ILogger Logger { get; set; }
    //public static IAssetBundleLoader AssetBundleLoader { get; set; }
    //public static IResourceLoader ResourceLoader { get; set; }

    public static IDatabase Database { get; set; }

    public static IExecutor DownloadExecutor { get; set; }

    //private static IExecutor LoadExecutor { set; }

    public static bool IsSetupped { get; set; }

    public static bool AllowDeleted { get; set; }

    //public static DownloadErrorHandler DownloadErrorInteceptor { get; set; }
    //public static AssetBundleLoadHandler AssetBundleLoadInterceptor { get; set; }
    //public static AssetBundleUnloadHandler OnAssetBundleUnloadCompleted { get; set; }

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
            throw new ArgumentNullException(nameof(settings));
        }

        IOctoSettings localSettings;
        if (!IsSetupped)
        {
            IsSetupped = true;
            DownloadExecutor = Internal._downloader = new Downloader();

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

                    //Internal._caching = new UnityCaching();
                    //AssetBundleLoader = new UnityAssetBundleLoader();
                    //ResourceLoader = null;
                    break;

                default:

                    Internal._caching = OctoHybridCaching.WrapIfNeeded(new OctoCaching(_settings, _settings.CachingType == CachingType.OctoAutoDelete));
                    //AssetBundleLoader = new OctoAssetBundleLoader(Internal._caching);
                    //ResourceLoader = new OctoResourceLoader(Internal._caching);
                    break;
            }
        }

        return true;
    }

    internal static class Internal
    {
        public static OctoAPI _octoAPI;
        public static DataManager _dataManager;
        public static Downloader _downloader;

        //public static LoadExecutor _loadExecutor;
        //public static Timer _timer;
        public static ICachingInternal _caching;

        //public static AssetBundleManager _assetBundleManager;
    }
}
