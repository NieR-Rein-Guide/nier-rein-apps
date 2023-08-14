using DustInTheWind.ConsoleTools.Controls.Menus;
using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;
using NierReincarnation.Datamine.Extension;

namespace NierReincarnation.Datamine.Command;

public class ExportWeaponStatsMenuCommand : AbstractMenuCommand<ExportWeaponStatsMenuCommandArg>
{
    public override bool IsActive => Program.AppSettings.IsSetup;

    public ExportWeaponStatsMenuCommand(ExportWeaponStatsMenuCommandArg arg) : base(arg) { }

    public override Task ExecuteAsync(ExportWeaponStatsMenuCommandArg arg)
    {
        Console.Clear();
        BuildMenu(arg.WeaponType).Display();

        return Task.CompletedTask;
    }

    private static TextMenu BuildMenu(WeaponType weaponType)
    {
        TextMenu textMenu = MenuExtensions.GetTextMenu();
        List<TextMenuItem> menuItems = new()
        {
            new TextMenuItem
            {
                Id = "0",
                Text = "Go Back",
                Command = new ExportWeaponTypeStoriesMenuCommand()
            }
        };

        int i = 1;
        foreach (var darkWeapon in MasterDb.EntityMWeaponTable.All.Where(x => x.WeaponType == weaponType))
        {
            if (darkWeapon.WeaponId >= 8000000 || darkWeapon.WeaponEvolutionMaterialGroupId > 0) continue;

            menuItems.Add(new TextMenuItem
            {
                Id = $"{i++}",
                Text = $"{CalculatorWeapon.WeaponName(darkWeapon.WeaponId)} ({darkWeapon.WeaponType.ToFormattedStr()}) ({darkWeapon.RarityType.ToFormattedStr(true)})",
                Command = new ExportWeaponStatMenuCommand(new ExportWeaponStatMenuCommandArg { WeaponId = darkWeapon.WeaponId })
            });
        }

        textMenu.AddItems(menuItems);

        return textMenu;
    }
}

public class ExportWeaponStatsMenuCommandArg
{
    public WeaponType WeaponType { get; init; }
}
