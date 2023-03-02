using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace NierReincarnation.Core.Dark.Calculator.Outgame
{
    public static class CalculatorCostumeEmblem
    {
        public static string GetEmblemName(int costumeEmblemAssetId)
        {
            return string.Format(UserInterfaceTextKey.Costume.kEmblemName, costumeEmblemAssetId).Localize();
        }
    }
}
