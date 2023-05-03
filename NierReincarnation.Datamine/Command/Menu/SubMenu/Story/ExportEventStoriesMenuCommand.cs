using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportEventStoriesMenuCommand : AbstractMenuCommand
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
        foreach (var darkEventQuestChapter in MasterDb.EntityMEventQuestChapterTable.All
            .Where(x => x.EventQuestType == EventQuestType.MARATHON && DateTimeExtensions.IsNotTestData(x.StartDatetime))
            .OrderBy(x => x.SortOrder))
        {
            menuItems.Add(new TextMenuItem
            {
                Id = $"{i++}",
                Text = string.Format(UserInterfaceTextKey.Quest.kEventChapterTitle, darkEventQuestChapter.NameEventQuestTextId).Localize(),
                Command = new ExportEventStoryMenuCommand(new ExportEventStoryMenuCommandArg { EventQuestChapterId = darkEventQuestChapter.EventQuestChapterId })
            });
        }

        textMenu.AddItems(menuItems);

        return textMenu;
    }
}
