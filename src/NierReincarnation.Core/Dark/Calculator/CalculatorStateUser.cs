using NierReincarnation.Core.Adam.Framework.Gameplay.Paradigm;

namespace NierReincarnation.Core.Dark.Calculator;

public class CalculatorStateUser
{
    public static long GetUserId()
    {
        try
        {
            var structure = GetStateUserDataStructure();
            var stateUser = structure.FieldStateUser();

            return stateUser.Id;
        }
        catch (Exception)
        {
            return -1;
        }
    }

    private static DataStructure GetStateUserDataStructure()
    {
        KernelState.GetUserState(out var structure);
        return structure;
    }
}
