using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportRodCharacterStoriesMenuCommand : AbstractMenuCommand
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
        foreach (var darkEventQuestChapterGroup in MasterDb.EntityMEventQuestChapterTable.All
            .Where(x => x.EventQuestType == EventQuestType.LIMIT_CONTENT)
            .OrderBy(x => x.StartDatetime)
            .GroupBy(x => CalculatorQuest.GetChapterCharacterId(x.EventQuestChapterId)))
        {
            var darkEventQuestChapter = darkEventQuestChapterGroup.First();

            menuItems.Add(new TextMenuItem
            {
                Id = $"{i++}",
                Text = CalculatorCharacter.GetCharacterName(CalculatorQuest.GetChapterCharacterId(darkEventQuestChapter.EventQuestChapterId)),
                Command = new ExportRodCharacterStoryMenuCommand(new ExportRodCharacterStoryMenuCommandArg { EventQuestChapterIds = darkEventQuestChapterGroup.Select(x => x.EventQuestChapterId).ToList() })
            });
        }

        textMenu.AddItems(menuItems);

        return textMenu;
    }
}
