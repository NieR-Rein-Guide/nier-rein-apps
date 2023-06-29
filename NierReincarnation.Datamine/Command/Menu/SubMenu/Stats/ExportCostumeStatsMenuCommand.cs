using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportCostumeStatsMenuCommand : AbstractMenuCommand<ExportCostumeStatsMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public ExportCostumeStatsMenuCommand(ExportCostumeStatsMenuCommandArg arg) : base(arg) { }

    public override Task ExecuteAsync(ExportCostumeStatsMenuCommandArg arg)
    {
        Console.Clear();
        BuildMenu(arg.CharacterId).Display();

        return Task.CompletedTask;
    }

    private static TextMenu BuildMenu(int characterId)
    {
        TextMenu textMenu = MenuExtensions.GetTextMenu();
        List<TextMenuItem> menuItems = new()
        {
            new TextMenuItem
            {
                Id = "0",
                Text = "Go Back",
                Command = new ExportCharacterCostumeStoriesMenuCommand()
            }
        };

        int i = 1;
        foreach (var darkCostume in MasterDb.EntityMCostumeTable.FindByCharacterId(characterId))
        {
            if (darkCostume.CostumeId >= 100000) continue;

            menuItems.Add(new TextMenuItem
            {
                Id = $"{i++}",
                Text = $"{CalculatorCostume.CostumeName(darkCostume.CostumeId)} ({darkCostume.RarityType.ToFormattedStr(false)})",
                Command = new ExportCostumeStatMenuCommand(new ExportCostumeStatMenuCommandArg { CostumeId = darkCostume.CostumeId })
            });
        }

        textMenu.AddItems(menuItems);

        return textMenu;
    }
}

public class ExportCostumeStatsMenuCommandArg
{
    public int CharacterId { get; init; }
}
