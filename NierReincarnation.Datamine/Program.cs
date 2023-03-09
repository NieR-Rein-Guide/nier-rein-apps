using CommandLine;
using DustInTheWind.ConsoleTools.Controls;
using DustInTheWind.ConsoleTools.Controls.Menus;
using DustInTheWind.ConsoleTools.Controls.Spinners;
using Newtonsoft.Json;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.UnityEngine;
using NierReincarnation.Datamine.Command;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine;

public static class Program
{
    public class Options
    {
        [Option('u', "username", Required = false, HelpText = "Set the username of the account.")]
        public string Username { get; set; } = "";

        [Option('p', "password", Required = false, HelpText = "Set the password of the account.")]
        public string Password { get; set; } = "";

        [Option('r', "revision", Required = false, HelpText = "Set the current database revision.")]
        public int DbRevision { get; set; }

        [Option('a', "appver", Required = false, HelpText = "Set the current app version.")]
        public string AppVersion { get; set; }

        [Option('w', "workingdir", Required = false, HelpText = "Set the working directory.")]
        public string WorkingfDir { get; set; } = Constants.DefaultWorkingDir;

        [Option("discord", Required = false, Default = false, HelpText = "Format dates for Discord")]
        public bool UseDiscordDates { get; set; }

        [Option("autocopy", Required = false, Default = false, HelpText = "Automatically copy assets to main folder")]
        public bool AutoCopyAssets { get; set; }

        [Option("usetemp", Required = false, Default = true, HelpText = "Place new files in a temp folder")]
        public bool UseTemp { get; set; } = true;

        [Option("timeout", Required = false, HelpText = "Timeout for asset downloads")]
        public TimeSpan Timeout { get; set; } = TimeSpan.FromMinutes(2);

        [JsonIgnore]
        public bool IsSetup => !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password) && DbRevision >= 0 && !string.IsNullOrEmpty(AppVersion) && !string.IsNullOrEmpty(WorkingfDir);
    }

    public static Options AppSettings { get; set; }

    public static void Main(string[] args)
    {
        try
        {
            using (Spinner spinner = MenuExtensions.GetSpinner())
            {
                try
                {
                    spinner.Display();
                    InitializeAppAsync(args).GetAwaiter().GetResult();
                }
                catch (Exception)
                {
                    spinner.Close();
                    throw;
                }
            }

            while (true)
            {
                Console.Clear();
                BuildMainMenu().Display();
                Pause.QuickDisplay();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);

            if (ex.InnerException != null)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.InnerException.StackTrace);
            }

            Pause.QuickDisplay();
        }
    }

    private static async Task InitializeAppAsync(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        try
        {
            var settingsFileExists = File.Exists(Constants.SettingsPath);

            AppSettings = args.Length > 0
                ? Parser.Default.ParseArguments<Options>(args).Value
                : settingsFileExists
                    ? JsonConvert.DeserializeObject<Options>(File.ReadAllText(Constants.SettingsPath)) ?? new()
                    : new();

            Directory.CreateDirectory(AppSettings.WorkingfDir);
        }
        catch (Exception)
        {
            AppSettings = new();
        }
        finally
        {
            Application.Version = AppSettings.AppVersion;
            //Application.Language = Language.Japanese;

            await new SaveConfigurationCommand().ExecuteAsync();
        }
    }

    private static TextMenu BuildMainMenu()
    {
        TextMenu textMenu = MenuExtensions.GetTextMenu($"NieR Re[in]carnation Dataminer | App: {AppSettings.AppVersion} | DB: {AppSettings.DbRevision} | User: {AppSettings.Username} | Workspace: {AppSettings.WorkingfDir}");

        textMenu.AddItems(new List<TextMenuItem>
        {
            new TextMenuItem
            {
                Id = "1",
                Text = "Export Assets & Resources",
                Command = new ExportAssetsResourcesMenuCommand()
            },
            new TextMenuItem
            {
                Id = "2",
                Text = "Export Localizations",
                Command = new ExportLocalizationsMenuCommand(new ExportLocalizationsMenuCommandArg
                {
                    Languages = new[] { Language.English, Language.Japanese },
                    //Inclusions = new List<string>
                    //{
                    //    "ability", "character", "costume_emblem", "companion", "costume", "parts", "thought", "weapon", "weapon_story", "skill", "story_character"
                    //}
                })
            },
            new TextMenuItem
            {
                Id = "3",
                Text = "Export Database",
                Command = new ExportDatabaseTablesMenuCommand()
            },
            new TextMenuItem
            {
                Id = "4",
                Text = "Export Gachas",
                Command = new ExportGachasMenuCommand(new ExportGachasCommandArg
                {
                    GachaLabelTypes = new List<GachaLabelType> { GachaLabelType.PREMIUM }
                })
            },
            new TextMenuItem
            {
                Id = "5",
                Text = "Export Memoirs",
                Command = new ExportMemoirsMenuCommand()
            },
            new TextMenuItem
            {
                Id = "6",
                Text = "Search Database",
                Command = new SearchDatabaseMenuCommand()
            },
            new TextMenuItem
            {
                Id = "7",
                Text = "Export Database Entity",
                Command = new ExportDatabaseEntityMenuCommand()
            },
            new TextMenuItem
            {
                Id = "8",
                Text = "Export Database News",
                Command = new ExportDatabaseNewsMenuCommand()
            },
            new TextMenuItem
            {
                Id = "9",
                Text = "Seek not the Watchers",
                Command = new WatcherMenuCommand()
            },
            new TextMenuItem
            {
                Id = "0",
                Text = "Configuration",
                Command = new ConfigurationMenuCommand()
            },
            new TextMenuItem
            {
                Id = "00",
                Text = "Testing",
                IsVisible = System.Diagnostics.Debugger.IsAttached,
                Command = new TestMenuCommand()
            },
        });

        return textMenu;
    }
}
