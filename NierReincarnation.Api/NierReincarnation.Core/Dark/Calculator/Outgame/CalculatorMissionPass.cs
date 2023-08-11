using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorMissionPass
{
    private const int kPremiumPossessionRewardCapacity = 50;
    public static readonly int kInvalidMissionPassId = 0;

    public static string GetMissionPointName() => UserInterfaceTextKey.Mission.kMissionPointName.Localize();

    public static string GetMissionPointDescription() => UserInterfaceTextKey.Mission.kMissionPointDescription.Localize();
}
