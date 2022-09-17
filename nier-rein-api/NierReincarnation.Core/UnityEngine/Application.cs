using System.Collections.Generic;
using System.IO;
using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.UnityEngine
{
    // UnityEngine.Application
    public static class Application
    {
        // CUSTOM: Versions and identifiers for each region the application can run in
        private static readonly IDictionary<Language, string> Versions = new Dictionary<Language, string>();
        private static readonly IDictionary<Language, string> Identifiers = new Dictionary<Language, string>();

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

            EnsurePaths();
        }

        #endregion

        static Application()
        {
            EnsureVersions();
            EnsureIdentifiers();

            EnsurePaths();
        }

        #region App

        public static string Version
        {
            get => Versions[Language];
            set => Versions[Language] = value;
        }

        public static string Identifier => Identifiers[Language];

        private static void EnsureVersions()
        {
            Versions[Language.English] = "2.11.0";
            Versions[Language.Japanese] = "2.10.11"; // TODO: Latest JP version
            Versions[Language.Malaysia] = "1.3.40";
        }

        private static void EnsureIdentifiers()
        {
            Identifiers[Language.English] = "com.square_enix.android_googleplay.nierspww";
            Identifiers[Language.Japanese] = "com.square_enix.android_googleplay.nierspww"; // TODO: JP Identifier
            Identifiers[Language.Malaysia] = "com.komoe.nierregp";
        }

        #endregion

        #region System

        // CUSTOM: Language specifier for which region the application should run
        public static Language Language { get; set; } = Language.English;

        public static string SystemLanguage => GetSystemLanguage();

        public static PlatformType Platform => PlatformType.GOOGLE_PLAY_STORE;

        #endregion

        private static void EnsurePaths()
        {
            EnsureDirectory(DataPath);
            EnsureDirectory(UserDataPath);
            EnsureDirectory(ApkPath);

            EnsureDirectory(SharedPrefsPath);
        }

        private static void EnsureDirectory(string dir)
        {
            Directory.CreateDirectory(dir);
        }

        private static string GetSystemLanguage()
        {
            switch (Language)
            {
                case Language.English:
                    return "English";

                case Language.Japanese:
                    return "Japanese";

                case Language.Malaysia:
                    return "Malaysia";

                default:
                    return string.Empty;
            }
        }
    }
}
