namespace NierReincarnation.Core.UnityEngine;

public static class Application
{
    private static string Root { get; } = ".\\resources";

    public static bool IsPlaying { get; }

    public static string BuildGUID { get; }

    public static string DataPath => Path.Combine(Root, "data", Identifier);

    public static string StreamingAssetsPath { get; }

    public static string PersistentDataPath => Path.Combine(Root, "user", "data", Identifier);

    public static string TemporaryCachePath { get; }

    public static string UnityVersion { get; }

    public static string Version { get; set; } = "3.6.0";

    public static string Identifier => "com.square_enix.android_googleplay.nierspww";

    public static string CloudProjectId { get; }

    public static int TargetFrameRate => 30;

    public static ThreadPriority BackgroundLoadingPriority => ThreadPriority.Normal;

    public static PlatformType Platform => PlatformType.GOOGLE_PLAY_STORE;

    //public static RuntimePlatform Platform => RuntimePlatform.Android;

    public static bool IsMobilePlatform => true;

    public static SystemLanguage SystemLanguage { get; set; } = SystemLanguage.English;

    public static NetworkReachability InternetReachability { get; }

    public static bool IsEditor { get; }

    public static string ApkPath => Path.Combine(Root, "apk");

    public static string SharedPrefsPath => Path.Combine(DataPath, "shared_prefs");

    // Custom
    public static SystemRegion SystemRegion { get; set; } = SystemRegion.GL;

    static Application()
    {
        try
        {
            Directory.CreateDirectory(DataPath);
            Directory.CreateDirectory(PersistentDataPath);
            Directory.CreateDirectory(ApkPath);
            Directory.CreateDirectory(SharedPrefsPath);
        }
        catch { }
    }
}
