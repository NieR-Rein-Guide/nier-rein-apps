using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Subsystem.Serval;

public static class CharacterServal
{
    public static int calcMaxLevel(NumericalFunctionType functionType, int[] functionParameters)
    {
        return FunctionsServal.calcParameter(functionType, functionParameters, new int[1]);
    }
}
