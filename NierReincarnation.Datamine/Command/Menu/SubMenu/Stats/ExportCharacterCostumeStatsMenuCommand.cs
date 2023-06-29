using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportCharacterCostumeStatsMenuCommand : AbstractMenuCommand
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
        foreach (var darkCharacter in MasterDb.EntityMCharacterTable.All.OrderBy(x => x.SortOrder))
        {
            var defaultCostumeId = CalculatorCostume.ActorAssetId(darkCharacter.DefaultCostumeId);
            if (string.IsNullOrEmpty(defaultCostumeId.StringId)) continue;

            menuItems.Add(new TextMenuItem
            {
                Id = $"{i++}",
                Text = CalculatorCharacter.CharacterName(darkCharacter.CharacterId),
                Command = new ExportCostumeStatsMenuCommand(new ExportCostumeStatsMenuCommandArg { CharacterId = darkCharacter.CharacterId })
            });
        }

        textMenu.AddItems(menuItems);

        return textMenu;
    }
}
