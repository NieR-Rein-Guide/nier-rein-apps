using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportWeaponTypeStoriesMenuCommand : AbstractMenuCommand
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
        List<TextMenuItem> menuItems =
        [
            new TextMenuItem
            {
                Id = "0",
                Text = "Go Back",
                Command = new ExportStoriesMenuCommand()
            }
        ];

        int i = 1;
        foreach (WeaponType weaponType in Enum.GetValues(typeof(WeaponType)))
        {
            if (weaponType == WeaponType.UNKNOWN || weaponType == WeaponType.COMPANION || weaponType == WeaponType.MT_WEAPON) continue;

            menuItems.Add(new TextMenuItem
            {
                Id = $"{i++}",
                Text = weaponType.ToFormattedStr(),
                Command = new ExportWeaponStoriesMenuCommand(new ExportWeaponStoriesMenuCommandArg { WeaponType = weaponType })
            });
        }

        textMenu.AddItems(menuItems);

        return textMenu;
    }
}
