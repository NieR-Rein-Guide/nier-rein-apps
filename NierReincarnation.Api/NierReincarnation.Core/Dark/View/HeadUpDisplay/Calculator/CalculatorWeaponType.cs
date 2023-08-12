using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;

public static class CalculatorWeaponType
{
    public static string GetWeaponTypeText(WeaponType weaponType)
    {
        return GetWeaponTypeText((int)weaponType);
    }

    public static string GetWeaponTypeText(int weaponType)
    {
        return string.Format(UserInterfaceTextKey.Common.kWeaponTypeTextKey, weaponType).Localize();
    }
}
