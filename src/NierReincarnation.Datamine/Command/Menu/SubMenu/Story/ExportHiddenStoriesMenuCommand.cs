using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportHiddenStoriesMenuCommand : AbstractMenuCommand
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
        foreach (var darkMainQuestSeason in MasterDb.EntityMMainQuestSeasonTable.All.OrderBy(x => x.SortOrder))
        {
            foreach (var darkReportGroup in MasterDb.EntityMReportTable.All
                .Where(x => x.MainQuestSeasonId == darkMainQuestSeason.MainQuestSeasonId)
                .GroupBy(x => NierReinExtensions.GetCharacterSymbolName(x.CharacterId)))
            {
                var characterSymbolName = NierReinExtensions.GetCharacterSymbolName(darkReportGroup.First().CharacterId);

                menuItems.Add(new TextMenuItem
                {
                    Id = $"{i++}",
                    Text = string.Format(UserInterfaceTextKey.Report.kReportSymbolTitle.Localize(), characterSymbolName),
                    Command = new ExportHiddenStoryMenuCommand(new ExportHiddenStoryMenuCommandArg { ReportIds = darkReportGroup.Select(x => x.ReportId).ToList() })
                });
            }
        }

        textMenu.AddItems(menuItems);

        return textMenu;
    }
}
