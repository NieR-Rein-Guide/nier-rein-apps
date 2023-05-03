using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportMainStoriesMenuCommand : AbstractMenuCommand
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
        List<TextMenuItem> menuItems = new()
        {
            new TextMenuItem
            {
                Id = "0",
                Text = "Go Back",
                Command = new ExportStoriesMenuCommand()
            }
        };

        int i = 1;
        foreach (var darkMainQuestChapter in MasterDb.EntityMMainQuestChapterTable.All.OrderBy(x => x.MainQuestRouteId).ThenBy(x => x.SortOrder))
        {
            (string chatperNumber, string chapterTitle) = CalculatorQuest.GetMainQuestChapterText(darkMainQuestChapter.MainQuestRouteId, darkMainQuestChapter.SortOrder);

            menuItems.Add(new TextMenuItem
            {
                Id = $"{i++}",
                Text = !chatperNumber.Equals(chapterTitle) ? $"{chatperNumber} ~ {chapterTitle}" : chatperNumber,
                Command = new ExportMainStoryMenuCommand(new ExportMainStoryMenuCommandArg { MainQuestChapterId = darkMainQuestChapter.MainQuestChapterId })
            });

            foreach (var darkLibraryMainQuestGroup in MasterDb.EntityMLibraryMainQuestGroupTable.All.Where(x => x.MainQuestChapterId == darkMainQuestChapter.MainQuestChapterId).OrderBy(x => x.SortOrder))
            {
                menuItems.Add(new TextMenuItem
                {
                    Id = $"{i++}",
                    Text = CalculatorQuest.GetMainQuestChapterTextWithTextAssetId(darkMainQuestChapter.MainQuestRouteId, darkMainQuestChapter.SortOrder, darkLibraryMainQuestGroup.ChapterTextAssetId),
                    Command = new ExportMainStoryMenuCommand(new ExportMainStoryMenuCommandArg { MainQuestChapterId = darkMainQuestChapter.MainQuestChapterId, LibraryMainQuestGroupId = darkLibraryMainQuestGroup.LibraryMainQuestGroupId })
                });
            }
        }

        textMenu.AddItems(menuItems);

        return textMenu;
    }
}
