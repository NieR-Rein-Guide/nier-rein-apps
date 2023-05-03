using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Core.Dark.Calculator.Outgame;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportCharacterCostumeStoriesMenuCommand : AbstractMenuCommand
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
        foreach (var darkCharacter in MasterDb.EntityMCharacterTable.All.OrderBy(x => x.SortOrder))
        {
            var defaultCostumeId = CalculatorCostume.ActorAssetId(darkCharacter.DefaultCostumeId);
            if (string.IsNullOrEmpty(defaultCostumeId.StringId)) continue;

            menuItems.Add(new TextMenuItem
            {
                Id = $"{i++}",
                Text = CalculatorCharacter.CharacterName(darkCharacter.CharacterId),
                Command = new ExportCostumeStoriesMenuCommand(new ExportCostumeStoriesMenuCommandArg { CharacterId = darkCharacter.CharacterId })
            });
        }

        textMenu.AddItems(menuItems);

        return textMenu;
    }
}
