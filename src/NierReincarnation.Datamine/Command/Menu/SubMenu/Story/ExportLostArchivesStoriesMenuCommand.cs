using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportLostArchivesStoriesMenuCommand : AbstractMenuCommand
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
        foreach (var darkCageMemory in MasterDb.EntityMCageMemoryTable.All.OrderBy(x => x.SortOrder))
        {
            var number = $"cage.memory.library.title.{darkCageMemory.CageMemoryAssetId:D6}".Localize();
            var title = $"cage.memory.title.{darkCageMemory.CageMemoryAssetId:D6}".Localize();

            menuItems.Add(new TextMenuItem
            {
                Id = $"{i++}",
                Text = $"{number} ~ {title}",
                Command = new ExportLostArchiveStoryMenuCommand(new ExportLostArchiveStoryMenuCommandArg { CageMemoryId = darkCageMemory.CageMemoryId })
            });
        }

        textMenu.AddItems(menuItems);

        return textMenu;
    }
}
