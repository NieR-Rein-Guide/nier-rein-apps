using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportCardStoriesMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override Task ExecuteAsync()
    {
        Console.Clear();
        BuildStoriesMenu().Display();

        return Task.CompletedTask;
    }

    private static TextMenu BuildStoriesMenu()
    {
        TextMenu textMenu = MenuExtensions.GetTextMenu();
        List<TextMenuItem> menuItems =
        [
            new TextMenuItem
            {
                Id = "0",
                Text = "Go Back",
                Command = new ExportStoriesMenuCommand()
            }
        ];

        int i = 1;
        foreach (var darkWebviewMission in MasterDb.EntityMWebviewMissionTable.All.OrderBy(x => x.WebviewMissionId))
        {
            var darkWebviewMissionTitleText = MasterDb.EntityMWebviewMissionTitleTextTable.FindByWebviewMissionTitleTextIdAndLanguageType((darkWebviewMission.TitleTextId, LanguageType.EN));

            menuItems.Add(new TextMenuItem
            {
                Id = $"{i++}",
                Text = darkWebviewMissionTitleText.Text,
                Command = new ExportCardStoryMenuCommand(new ExportCardStoryMenuCommandArg { WebviewMissionId = darkWebviewMission.WebviewMissionId })
            });
        }

        textMenu.AddItems(menuItems);

        return textMenu;
    }
}
