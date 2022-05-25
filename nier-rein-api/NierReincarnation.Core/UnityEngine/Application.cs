using System.IO;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.UnityEngine
{
    // UnityEngine.Application
    public static class Application
    {
        #region Paths

        // CUSTOM: The root for all relative path properties
        // By default set to the test user resource root
        private static string Root { get; set; } = ".\\resources";

        // CUSTOM: To access downloaded assets and resources
        public static string DataPath => Path.Combine(Root, "data", Identifier);

        // CUSTOM: To access data in the accessible storage of the user (eg. /storage/emulated/0/Android/[...])
        public static string UserDataPath => Path.Combine(Root, "user", "data", Identifier);

        // CUSTOM: To access assets from the APK
        public static string ApkPath => Path.Combine(Root, "apk");

        // CUSTOM: To access the player preferences with the same pattern as all other paths in the engine
        public static string SharedPrefsPath => Path.Combine(DataPath, "shared_prefs");

        // CUSTOM: Sets root for all relative path properties
        public static void SetRoot(string root)
        {
            Root = root;

            EnsureDirectory(DataPath);
            EnsureDirectory(UserDataPath);
            EnsureDirectory(ApkPath);

            EnsureDirectory(SharedPrefsPath);
        }

        static Application()
        {
            EnsureDirectory(DataPath);
            EnsureDirectory(UserDataPath);
            EnsureDirectory(ApkPath);

            EnsureDirectory(SharedPrefsPath);
        }

        #endregion

        #region App

        public static string Version => "2.8.5";

        public static string Identifier => "com.square_enix.android_googleplay.nierspww";

        #endregion

        #region System

        public static string SystemLanguage => "English";

        public static PlatformType Platform => PlatformType.GOOGLE_PLAY_STORE;

        #endregion

        private static void EnsureDirectory(string dir)
        {
            Directory.CreateDirectory(dir);
        }
    }
}
