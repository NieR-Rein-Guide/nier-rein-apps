using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Subsystem.Serval
{
    static class WeaponServal
    {
        public static int calcStatusValue(int initialValue, int currentLevel, NumericalFunctionType functionType, int[] functionParameters, int growthCurveCoefficientThreshold, int growthCurveCoefficient)
        {
            var rawValue = calcCurrentLevelRawStatusValue(initialValue, currentLevel, functionType, functionParameters);
            if (growthCurveCoefficientThreshold >= currentLevel)
                return rawValue;

            var rawGrowthValue = calcCurrentLevelRawStatusValue(initialValue, growthCurveCoefficientThreshold, functionType, functionParameters);
            var growthCappedValue = (rawValue - rawGrowthValue) * growthCurveCoefficient / 1000;

            return rawGrowthValue + growthCappedValue;
        }

        public static int CalcMaxSkillLevel(int limitBreakCount, NumericalFunctionType functionType, int[] functionParameters)
        {
            return FunctionsServal.calcParameter(functionType, functionParameters, new[] { limitBreakCount });
        }

        public static int CalcMaxAbilityLevel(int limitBreakCount, NumericalFunctionType functionType, int[] functionParameters)
        {
            return FunctionsServal.calcParameter(functionType, functionParameters, new[] { limitBreakCount });
        }

        public static int CalcMaxLevel(int limitBreakCount, int awakenLevelLimitUp, NumericalFunctionType functionType, int[] functionParameters)
        {
            return awakenLevelLimitUp + FunctionsServal.calcParameter(functionType, functionParameters, new[] { limitBreakCount });
        }

        public static int calcCurrentLevelRawStatusValue(int initialValue, int currentLevel, NumericalFunctionType functionType, int[] functionParameters)
        {
            return initialValue + FunctionsServal.calcParameter(functionType, functionParameters, new[] { currentLevel });
        }
    }
}
