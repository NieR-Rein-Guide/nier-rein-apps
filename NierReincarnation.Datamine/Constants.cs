using NierReincarnation.Core.UnityEngine;

namespace NierReincarnation.Datamine;

public static class Constants
{
    public static string DefaultWorkingDir => Path.Combine(AppContext.BaseDirectory, "dump");

    public static string SettingsPath => Path.Combine(AppContext.BaseDirectory, "appsettings.json");

    public static string LocalizationsPath => Path.Combine(Program.AppSettings.WorkingfDir, "assets", "text");

    public static string DatabasePath => Path.Combine(Program.AppSettings.WorkingfDir, "db");

    public static string DataPath => Path.Combine(Program.AppSettings.WorkingfDir, "data");

    public static string AssetsPath => Path.Combine(Program.AppSettings.WorkingfDir, "assets");

    public static string AssetsLatestPath => Path.Combine(Program.AppSettings.WorkingfDir, "assets_latest");

    public static string AssetsRawPath => Path.Combine(Program.AppSettings.WorkingfDir, "assets_raw");

    public static string ResourcesPath => Path.Combine(Program.AppSettings.WorkingfDir, "resources");

    public static string PlayerPrefsFile => Path.Combine(Application.SharedPrefsPath, Application.Identifier + ".v2.playerprefs.xml");

    public static string TempFolder => "temp";

    public static string ChangelogFolder => "changelog";

    public static string AllLocalizationsFile => "all_localizations";
}
