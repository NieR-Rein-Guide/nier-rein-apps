using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportCostumeStoriesMenuCommand : AbstractMenuCommand<ExportCostumeStoriesMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public ExportCostumeStoriesMenuCommand(ExportCostumeStoriesMenuCommandArg arg) : base(arg) { }

    public override Task ExecuteAsync(ExportCostumeStoriesMenuCommandArg arg)
    {
        Console.Clear();
        BuildStoriesMenu(arg.CharacterId).Display();

        return Task.CompletedTask;
    }

    private static TextMenu BuildStoriesMenu(int characterId)
    {
        TextMenu textMenu = MenuExtensions.GetTextMenu();
        List<TextMenuItem> menuItems =
        [
            new TextMenuItem
            {
                Id = "0",
                Text = "Go Back",
                Command = new ExportCharacterCostumeStoriesMenuCommand()
            }
        ];

        int i = 1;
        foreach (var darkCostume in MasterDb.EntityMCostumeTable.FindByCharacterId(characterId))
        {
            if (darkCostume.CostumeId >= 100000) continue;

            menuItems.Add(new TextMenuItem
            {
                Id = $"{i++}",
                Text = $"{CalculatorCostume.CostumeName(darkCostume.CostumeId)} ({darkCostume.RarityType.ToFormattedStr(false)})",
                Command = new ExportCostumeStoryMenuCommand(new ExportCostumeStoryMenuCommandArg { CostumeId = darkCostume.CostumeId })
            });
        }

        textMenu.AddItems(menuItems);

        return textMenu;
    }
}

public class ExportCostumeStoriesMenuCommandArg
{
    public int CharacterId { get; init; }
}
