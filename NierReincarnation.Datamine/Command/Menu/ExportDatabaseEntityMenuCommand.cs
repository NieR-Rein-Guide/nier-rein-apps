using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportDatabaseEntityMenuCommand : AbstractMenuCommand
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
                Text = "Configuration",
                Command = new ExportGameConfigurationMenuCommand()
            },
            new TextMenuItem
            {
                Id = "2",
                Text = "Unreleased Costumes",
                Command = new ExportUnreleasedCostumesMenuCommand()
            },
            new TextMenuItem
            {
                Id = "3",
                Text = "Mama News",
                Command = new ExportMamaNewsMenuCommand()
            },
            new TextMenuItem
            {
                Id = "4",
                Text = "Shops",
                Command = new ExportShopsMenuCommand()
            },
            new TextMenuItem
            {
                Id = "5",
                Text = "Subjugation",
                Command = new ExportSubjugationMenuCommand()
            },
            new TextMenuItem
            {
                Id = "6",
                Text = "Missions",
                Command = new ExportMissionsMenuCommand()
            },
            new TextMenuItem
            {
                Id = "7",
                Text = "Quest Campaigns",
                Command = new ExportQuestCampaignsMenuCommand()
            },
            new TextMenuItem
            {
                Id = "8",
                Text = "Enhancement Campaigns",
                Command = new ExportEnhanceCampaignsMenuCommand()
            },
            new TextMenuItem
            {
                Id = "9",
                Text = "Burden Effects",
                Command = new ExportBurdensMenuCommand()
            },
            new TextMenuItem
            {
                Id = "10",
                Text = "Explorations",
                Command = new ExportExplorationMenuCommand()
            },
            new TextMenuItem
            {
                Id = "11",
                Text = "Maintenances",
                Command = new ExportMaintenanceMenuCommand()
            },
            new TextMenuItem
            {
                Id = "12",
                Text = "Map Gimmicks",
                Command = new ExportGimmicksMenuCommand()
            },
            new TextMenuItem
            {
                Id = "13",
                Text = "Library Movies",
                Command = new ExportMoviesMenuCommand()
            },
            new TextMenuItem
            {
                Id = "14",
                Text = "Mission Pass",
                Command = new ExportMissionPassMenuCommand()
            },
            new TextMenuItem
            {
                Id = "101",
                Text = "Costume Info",
                Command = new ExportCostumeInfoMenuCommand()
            },
            new TextMenuItem
            {
                Id = "102",
                Text = "Weapon Info",
                Command = new ExportWeaponInfoMenuCommand()
            }
        });

        return textMenu;
    }
}
