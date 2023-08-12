using NierReincarnation.Core.Dark.EntryPoint;
using NierReincarnation.Core.Dark.Kernel;
using NierReincarnation.Core.Octo;

namespace NierReincarnation.Core.Adam.Framework.Resource;

public static class DarkOctoSetupper
{
    private static readonly Dictionary<string, Stream> Streams = new();
    private static bool _isSetup;
    private static bool _isReviewEnvironment;
    private static readonly OctoSettings _overwriteSetting;
    public static readonly string OverwriteSettingPath = "settings/octo/octo_overwrite_config";

    public static void StartSetup(bool reset = false, bool enableAssetDatabase = false)
    {
        SetupOcto(reset, enableAssetDatabase);

        // Set AssetBundleLoadInterceptor and OnAssetBundleUnloadCompleted on OctoManager

        _isSetup = true;
    }

    public static void SetupOcto(bool reset = false, bool enableAssetDatabase = false)
    {
        _isReviewEnvironment = ApplicationApi.IsReviewEnvironment();

        var settings = CreateSetting();
        settings.EnableAssetDatabase = enableAssetDatabase;

        OctoManager.Setup(settings, reset);
    }

    public static OctoFullSettings CreateSetting()
    {
        if (_overwriteSetting == null)
        {
            // Unity: Load resource from path OverwriteSettingPath with type 'OctoSettings' Set loaded settings to field 0x10
        }

        return new OctoFullSettings
        {
            AppId = GetA(),
            ClientSecretKey = GetB(),
            AesKey = GetC(),
            Version = GetD(),
            Url = GetE(),
            A = GetF(),

            AssetLoaderPriority = AssetLoader.LoadPriority.AssetBundle,
            ExpirationDelay = 0,
            CachingType = CachingType.OctoFullCache,
            MaximumAvailableDiskSpace = -1,
            MaxParallelDownload = 4,
            MaxParallelLoad = 100,
            AllowDeleted = false
        };
    }

    private static int GetA()
    {
        if (_isReviewEnvironment)
            return ApplicationApi.GetReviewEnvironmentOctoAppId();

        if (_overwriteSetting != null)
            return _overwriteSetting.AppId;

        return Config.Octo.AppId;
    }

    private static string GetB()
    {
        if (_isReviewEnvironment)
            return ApplicationApi.GetReviewEnvironmentOctoClientSecretKey();

        if (_overwriteSetting != null)
            return _overwriteSetting.ClientSecretKey;

        return Config.Octo.ClientSecretKey;
    }

    private static string GetC()
    {
        if (_isReviewEnvironment)
            return ApplicationApi.GetReviewEnvironmentOctoAesKey();

        if (_overwriteSetting != null)
            return _overwriteSetting.AesKey;

        return Config.Octo.AesKey;
    }

    public static int GetD()
    {
        if (_isReviewEnvironment)
            return ApplicationApi.GetReviewEnvironmentOctoVersion();

        return GetOriginalD();
    }

    public static int GetOriginalD()
    {
        if (_overwriteSetting != null)
            return _overwriteSetting.Version;

        return Config.Octo.Version;
    }

    private static string GetE()
    {
        if (_isReviewEnvironment)
            return ApplicationApi.GetReviewEnvironmentOctoUrl();

        if (_overwriteSetting != null)
            return _overwriteSetting.Url;

        return Config.Octo.Url;
    }

    private static string GetF()
    {
        if (_isReviewEnvironment)
            return $"dark_{GetA()}_{GetD()}";

        if (_overwriteSetting != null)
            return _overwriteSetting.A;

        return Config.Octo.A;
    }
}
