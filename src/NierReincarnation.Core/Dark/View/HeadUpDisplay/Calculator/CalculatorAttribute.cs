using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace NierReincarnation.Core.Dark.View.HeadUpDisplay.Calculator;

public static class CalculatorAttribute
{
    public static string GetAttributeText(AttributeType attributeType)
    {
        return GetAttributeText((int)attributeType);
    }

    public static string GetAttributeText(int attributeType)
    {
        return string.Format(UserInterfaceTextKey.Common.kAttributeTextKey, attributeType).Localize();
    }
}
