using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class WatcherMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override bool UseApi => false;

    public override bool UseLocalizations => false;

    public override Task ExecuteAsync()
    {
        Console.Clear();
        BuildMainMenu().Display();

        return Task.CompletedTask;
    }

    private static TextMenu BuildMainMenu()
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
                Text = "Database Revision",
                Command = new RevisionWatcherMenuCommand(new RevisionWatcherMenuCommandArg())
            },
            new TextMenuItem
            {
                Id = "2",
                Text = "Master Database",
                Command = new MasterDatabaseWatcherMenuCommand(new MasterDatabaseWatcherMenuCommandArg())
            }
        });

        return textMenu;
    }
}
