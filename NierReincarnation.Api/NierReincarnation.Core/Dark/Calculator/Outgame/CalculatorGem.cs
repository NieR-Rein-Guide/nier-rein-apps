using NierReincarnation.Core.Dark.Localization;
using NierReincarnation.Core.Dark.View.UserInterface.Text;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorGem
{
    public static int PossessionAllGemCount(long userId)
    {
        var table = DatabaseDefine.User.EntityIUserGemTable;
        var gems = table.FindByUserId(userId);
        if (gems == null)
            return 0;

        return gems.FreeGem + gems.PaidGem;
    }


    public static int PossessionFreeGemCount(long userId)
    {
        var table = DatabaseDefine.User.EntityIUserGemTable;
        var gems = table.FindByUserId(userId);
        if (gems == null)
            return 0;

        return gems.FreeGem;
    }

    public static int PossessionPaidGemCount(long userId)
    {
        var table = DatabaseDefine.User.EntityIUserGemTable;
        var gems = table.FindByUserId(userId);
        if (gems == null)
            return 0;

        return gems.PaidGem;
    }

    // CUSTOM: Made method public for use in StaminaContext.cs
    public static EntityIUserGem GetEntityIUserGemTable(long userId)
    {
        var table = DatabaseDefine.User.EntityIUserGemTable;
        return table.FindByUserId(userId);
    }

    public static string PaidGemName()
    {
        return UserInterfaceTextKey.Gem.kPaidNameTextKey.Localize();
    }

    public static string FreeGemName()
    {
        return UserInterfaceTextKey.Gem.kFreeNameTextKey.Localize();
    }

    public static string Name()
    {
        return UserInterfaceTextKey.Gem.kNameTextKey.Localize();
    }
}
