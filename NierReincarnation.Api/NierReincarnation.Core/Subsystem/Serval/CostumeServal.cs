using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Subsystem.Serval
{
    static class CostumeServal
    {
        public static int calcMaxLevel(int limitBreakCount, NumericalFunctionType functionType, int[] functionParameters)
        {
            return FunctionsServal.calcParameter(functionType, functionParameters, new[] { limitBreakCount });
        }

        public static int calcStatusValue(int initialValue, int currentLevel, NumericalFunctionType functionType, int[] functionParameters)
        {
            return initialValue + FunctionsServal.calcParameter(functionType, functionParameters, new[] { currentLevel });
        }

        public static int calcActiveSkillMaxLevel(NumericalFunctionType functionType, int[] functionParameters)
        {
            return FunctionsServal.calcParameter(functionType, functionParameters, new[] { 1 });
        }
    }
}
