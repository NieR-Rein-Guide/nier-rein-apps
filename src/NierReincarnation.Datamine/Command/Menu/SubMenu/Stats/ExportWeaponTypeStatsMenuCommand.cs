using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportWeaponTypeStatsMenuCommand : AbstractMenuCommand
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
                Command = new ExportStatsMenuCommand()
            }
        };

        int i = 1;
        foreach (WeaponType weaponType in Enum.GetValues(typeof(WeaponType)))
        {
            if (weaponType == WeaponType.UNKNOWN || weaponType == WeaponType.COMPANION || weaponType == WeaponType.MT_WEAPON) continue;

            menuItems.Add(new TextMenuItem
            {
                Id = $"{i++}",
                Text = weaponType.ToFormattedStr(),
                Command = new ExportWeaponStatsMenuCommand(new ExportWeaponStatsMenuCommandArg { WeaponType = weaponType })
            });
        }

        textMenu.AddItems(menuItems);

        return textMenu;
    }
}
