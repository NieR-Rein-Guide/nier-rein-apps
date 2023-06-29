using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

internal class ExportStatsMenuCommand : AbstractMenuCommand
{
    public override bool UseApi => false;

    public override bool UseLocalizations => false;

    public override Task ExecuteAsync()
    {
        Console.Clear();
        BuildMenu().Display();

        return Task.CompletedTask;
    }

    private static TextMenu BuildMenu()
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
                Text = "Costumes",
                Command = new ExportCharacterCostumeStatsMenuCommand()
            },
            new TextMenuItem
            {
                Id = "2",
                Text = "Weapons",
                Command = new ExportWeaponTypeStatsMenuCommand()
            },
            new TextMenuItem
            {
                Id = "3",
                Text = "Companions",
                Command = new ExportCompanionStatsMenuCommand()
            },
        });

        return textMenu;
    }
}
