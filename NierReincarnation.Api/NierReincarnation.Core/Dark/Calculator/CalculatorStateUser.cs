using NierReincarnation.Core.Adam.Framework.Gameplay.Paradigm;

namespace NierReincarnation.Core.Dark.Calculator;

public class CalculatorStateUser
{
    public static long GetUserId()
    {
        var structure = GetStateUserDataStructure();
        var stateUser = structure.FieldStateUser();

        return stateUser.Id;
    }

    private static DataStructure GetStateUserDataStructure()
    {
        KernelState.GetUserState(out var structure);
        return structure;
    }
}
