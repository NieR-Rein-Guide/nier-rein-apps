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
        Console.WriteLine($"Username: {AppSettings.Username}");
        Console.WriteLine($"App Version: {AppSettings.AppVersion}");
        Console.WriteLine($"DB Revision: {AppSettings.DbRevision}");
        Console.WriteLine($"Working Directory: {AppSettings.WorkingfDir}");
        Console.WriteLine($"Date Format: {(AppSettings.UseDiscordDates ? "Discord" : "Normal")}");
        Console.WriteLine($"Asset Download Timeout: {AppSettings.Timeout}");
        Console.WriteLine($"Asset Auto Copy: {(AppSettings.AutoCopyAssets ? "Yes" : "No")}");
        Console.WriteLine($"Use Temp Folder: {(AppSettings.UseTemp ? "Yes" : "No")}");
        Console.WriteLine();

        BuildSubMenu().Display();

        return Task.CompletedTask;
    }

    private static TextMenu BuildSubMenu()
    {
        TextMenu textMenu = MenuExtensions.GetTextMenu();

        textMenu.AddItems(new List<TextMenuItem>
        {
            new TextMenuItem
            {
                Id = "0",
                Text = "Go Back",
                Command = new GoBackMenuCommand()
            },
            new TextMenuItem
            {
                Id = "1",
                Text = "Change Account",
                Command = new UpdateAccountMenuCommand(new UpdateConfigurationCommandArg { Reset = true })
            },
            new TextMenuItem
            {
                Id = "2",
                Text = "Change Database Revision",
                Command = new UpdateDbRevisionMenuCommand(new UpdateConfigurationCommandArg { Reset = true })
            },
            new TextMenuItem
            {
                Id = "3",
                Text = "Change App Version",
                Command = new UpdateAppVersionMenuCommand(new UpdateConfigurationCommandArg { Reset = true })
            },
            new TextMenuItem
            {
                Id = "4",
                Text = "Change Working Directory",
                Command = new UpdateWorkingDirMenuCommand(new UpdateConfigurationCommandArg())
            },
            new TextMenuItem
            {
                Id = "5",
                Text = "Change Date Format",
                Command = new UpdateDateFormatMenuCommand(new UpdateConfigurationCommandArg())
            },
            new TextMenuItem
            {
                Id = "6",
                Text = "Change Asset Download Timeout",
                Command = new UpdateAssetDownloadTimeoutMenuCommand(new UpdateConfigurationCommandArg())
            },
            new TextMenuItem
            {
                Id = "7",
                Text = "Change Asset Auto Copy Behavior",
                Command = new UpdateAssetAutoCopyMenuCommand(new UpdateConfigurationCommandArg())
            },
            new TextMenuItem
            {
                Id = "8",
                Text = "Change Temp Folder Use Behavior",
                Command = new UpdateUseTempMenuCommand(new UpdateConfigurationCommandArg())
            }
        });

        return textMenu;
    }
}
