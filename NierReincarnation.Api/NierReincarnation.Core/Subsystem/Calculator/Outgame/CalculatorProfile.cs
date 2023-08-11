using NierReincarnation.Core.Dark;

namespace NierReincarnation.Core.Subsystem.Calculator.Outgame;

public static class CalculatorProfile
{
    public static string GetName(long userId)
    {
        return GetEntityIUserProfile(userId)?.Name;
    }

    private static EntityIUserProfile GetEntityIUserProfile(long userId)
    {
        var table = DatabaseDefine.User?.EntityIUserProfileTable;
        return table?.FindByUserId(userId);
    }
}
