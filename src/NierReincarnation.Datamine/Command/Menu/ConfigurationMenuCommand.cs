using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Datamine.Extension;
using static NierReincarnation.Datamine.Program;

namespace NierReincarnation.Datamine.Command;

public class ConfigurationMenuCommand : AbstractMenuCommand
{
    public override bool UseApi => false;

    public override bool UseLocalizations => false;

    private static Options AppSettings => Program.AppSettings;

    public override Task ExecuteAsync()
    {
        Console.Clear();
        Console.WriteLine("=====CONFIGURATION=====");
        Console.WriteLine($"Region: {AppSettings.SystemRegion}");
        Console.WriteLine($"App Version: {AppSettings.AppVersion}");
        Console.WriteLine($"DB Revision: {AppSettings.DbRevision}");
        Console.WriteLine($"Working Directory: {AppSettings.WorkingfDir}");
        Console.WriteLine($"Date Format: {(AppSettings.UseDiscordDates ? "Discord" : "Normal")}");
        Console.WriteLine($"Asset Auto Copy: {(AppSettings.AutoCopyAssets ? "Yes" : "No")}");
        Console.WriteLine($"Operation Mode: {(AppSettings.IsOfflineMode ? "Offline" : "Online")}");
        Console.WriteLine();

        BuildSubMenu().Display();

        return Task.CompletedTask;
    }

    private static TextMenu BuildSubMenu()
    {
        TextMenu textMenu = MenuExtensions.GetTextMenu();

        textMenu.AddItems(new List<TextMenuItem>
        {
            new() {
                Id = "0",
                Text = "Go Back",
                Command = new GoBackMenuCommand()
            },
            new() {
                Id = "1",
                Text = "Remove Account",
                Command = new RemoveAccountMenuCommand(new UpdateConfigurationCommandArg { Reset = true })
            },
            new() {
                Id = "2",
                Text = "Set Database Revision",
                Command = new UpdateDbRevisionMenuCommand(new UpdateConfigurationCommandArg { Reset = true })
            },
            new() {
                Id = "3",
                Text = "Set App Version",
                Command = new UpdateAppVersionMenuCommand(new UpdateConfigurationCommandArg { Reset = true })
            },
            new() {
                Id = "4",
                Text = "Set Working Directory",
                Command = new UpdateWorkingDirMenuCommand(new UpdateConfigurationCommandArg())
            },
            new() {
                Id = "5",
                Text = "Set Region",
                Command = new UpdateSystemRegionMenuCommand(new UpdateConfigurationCommandArg() { Reset = true } )
            },
            new() {
                Id = "6",
                Text = "Set Date Format",
                Command = new UpdateDateFormatMenuCommand(new UpdateConfigurationCommandArg())
            },
            new() {
                Id = "7",
                Text = "Set Asset Auto Copy Behavior",
                Command = new UpdateAssetAutoCopyMenuCommand(new UpdateConfigurationCommandArg())
            },
            new() {
                Id = "8",
                Text = "Refresh Localization Cache",
                Command = new RefreshLocalizationCacheMenuCommand(new UpdateConfigurationCommandArg())
            },
            new() {
                Id = "9",
                Text = "Set Operation Mode",
                Command = new ToggleOperatingModeMenuCommand(new UpdateConfigurationCommandArg())
            }
        });

        return textMenu;
    }
}
