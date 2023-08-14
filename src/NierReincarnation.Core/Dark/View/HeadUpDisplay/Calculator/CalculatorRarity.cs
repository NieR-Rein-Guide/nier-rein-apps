using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;

public static class CalculatorRarity
{
    public static string GetRarityName(int rarityType)
    {
        return string.Format(UserInterfaceTextKey.Common.kRarityName, rarityType).Localize();
    }
}
