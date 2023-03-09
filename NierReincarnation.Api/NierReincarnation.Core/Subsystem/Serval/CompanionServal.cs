using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Subsystem.Serval
{
    static class CompanionServal
    {
        public static int calcStatusValue(int initialValue, int currentLevel, NumericalFunctionType functionType, int[] functionParameters)
        {
            return initialValue + FunctionsServal.calcParameter(functionType, functionParameters, new[] { currentLevel });
        }
    }
}
