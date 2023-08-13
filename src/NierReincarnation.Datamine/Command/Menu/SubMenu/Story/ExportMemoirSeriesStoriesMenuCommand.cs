using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportMemoirSeriesStoriesMenuCommand : AbstractMenuCommand
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
        foreach (var darkMemoirSeries in MasterDb.EntityMPartsSeriesTable.All)
        {
            menuItems.Add(new TextMenuItem
            {
                Id = $"{i++}",
                Text = CalculatorMemory.MemorySeriesName(darkMemoirSeries.PartsSeriesId),
                Command = new ExportMemoirStoryMenuCommand(new ExportMemoirStoryMenuCommandArg { PartsSeriesId = darkMemoirSeries.PartsSeriesId })
            });
        }

        textMenu.AddItems(menuItems);

        return textMenu;
    }
}
