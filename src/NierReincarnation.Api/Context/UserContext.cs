using NierReincarnation.Core.Subsystem.Calculator.Outgame;

namespace NierReincarnation.Context;

public class UserContext
{
    internal UserContext()
    { }

    public static string GetUserName()
    {
        return CalculatorProfile.GetName(GetUserId());
    }

    public static int GetUserLevel()
    {
        return CalculatorUserStatus.GetCurrentUserLevel();
    }

    public static long GetUserId()
    {
        return CalculatorStateUser.GetUserId();
    }

    public static int GetCurrentStamina()
    {
        return StaminaContext.GetCurrentStamina();
    }

    public static int GetMaxStamina()
    {
        return StaminaContext.GetMaxStamina();
    }
}
