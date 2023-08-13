using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Core.Subsystem.Calculator.Outgame;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportCompanionStatsMenuCommand : AbstractMenuCommand
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public override Task ExecuteAsync()
    {
        Console.Clear();
        BuildMenu().Display();

        return Task.CompletedTask;
    }

    private static TextMenu BuildMenu()
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
        foreach (var darkCompanion in MasterDb.EntityMCompanionTable.All.OrderBy(x => CalculatorCompanion.CompanionName(x.CompanionId).Split(":").ElementAtOrDefault(0)))
        {
            if (darkCompanion.CompanionId >= 8000000) continue;

            menuItems.Add(new TextMenuItem
            {
                Id = $"{i++}",
                Text = $"{CalculatorCompanion.CompanionName(darkCompanion.CompanionId)} ({darkCompanion.AttributeType.ToFormattedStr()})",
                Command = new ExportCompanionStatMenuCommand(new ExportCompanionStatMenuCommandArg { CompanionId = darkCompanion.CompanionId })
            });
        }

        textMenu.AddItems(menuItems);

        return textMenu;
    }
}
