using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

internal class ExportStoriesMenuCommand : AbstractMenuCommand
{
    public override bool UseApi => false;

    public override bool UseLocalizations => false;

    public override Task ExecuteAsync()
    {
        Console.Clear();
        BuildStoriesMenu().Display();

        return Task.CompletedTask;
    }

    private static TextMenu BuildStoriesMenu()
    {
        TextMenu textMenu = MenuExtensions.GetTextMenu();

        textMenu.AddItems(new List<TextMenuItem>()
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
                Text = "Main Stories",
                Command = new ExportMainStoriesMenuCommand()
            },
            new TextMenuItem
            {
                Id = "2",
                Text = "Character Stories",
                Command = new ExportCharacterStoriesMenuCommand()
            },
            new TextMenuItem
            {
                Id = "3",
                Text = "EX Character Stories",
                Command = new ExportExCharacterStoriesMenuCommand()
            },
            new TextMenuItem
            {
                Id = "4",
                Text = "RoD Character Stories",
                Command = new ExportRodCharacterStoriesMenuCommand()
            },
            new TextMenuItem
            {
                Id = "5",
                Text = "Event Stories",
                Command = new ExportEventStoriesMenuCommand()
            },
            new TextMenuItem
            {
                Id = "6",
                Text = "Card Stories",
                Command = new ExportCardStoriesMenuCommand()
            },
            new TextMenuItem
            {
                Id = "7",
                Text = "Hidden Stories",
                Command = new ExportHiddenStoriesMenuCommand()
            },
            new TextMenuItem
            {
                Id = "8",
                Text = "Lost Archives",
                Command = new ExportLostArchivesStoriesMenuCommand()
            }
        });

        return textMenu;
    }
}
