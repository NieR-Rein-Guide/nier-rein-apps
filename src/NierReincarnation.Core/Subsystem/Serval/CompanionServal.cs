namespace NierReincarnation.Core.Subsystem.Serval;

public static class CompanionServal
{
    public static int calcRequiredGold(int level, NumericalFunctionType functionType, int[] functionParameters)
    {
        return FunctionsServal.calcParameter(functionType, functionParameters, new[] { level });
    }

    public static int calcStatusValue(int initialValue, int currentLevel, NumericalFunctionType functionType, int[] functionParameters)
    {
        return initialValue + FunctionsServal.calcParameter(functionType, functionParameters, new[] { currentLevel });
    }
}
