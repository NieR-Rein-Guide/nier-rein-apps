using NierReincarnation.Core.Dark.Generated.Type;

namespace NierReincarnation.Core.Subsystem.Serval
{
    public static class CostumeServal
    {
        public static int calcMaxLevel(int limitBreakCount, int rebirthLevelLimitUp, NumericalFunctionType functionType, int[] functionParameters)
        {
            return rebirthLevelLimitUp + FunctionsServal.calcParameter(functionType, functionParameters, new[] { limitBreakCount });
        }

        public static int calcActiveSkillMaxLevel(NumericalFunctionType functionType, int[] functionParameters)
        {
            return FunctionsServal.calcParameter(functionType, functionParameters, new[] { 1 });
        }

        public static int calcEnhancementExp(int baseValue, bool isSameWeaponType, int weaponCoefficientPermil)
        {
            return EnhancementServal.calcEnhancementExpByMaterial(baseValue, isSameWeaponType, weaponCoefficientPermil);
        }

        public static int calcRequiredGoldForEnhancement(int materialCount, NumericalFunctionType functionType, int[] functionParameters)
        {
            return FunctionsServal.calcParameter(functionType, functionParameters, new[] { materialCount });
        }

        public static int calcRequiredGoldForActiveSkillEnhancement(int enhancedLevel, NumericalFunctionType functionType, int[] functionParameters)
        {
            return FunctionsServal.calcParameter(functionType, functionParameters, new[] { enhancedLevel });
        }

        public static int calcRequiredGoldForLimitBreak(int materialCount, NumericalFunctionType functionType, int[] functionParameters)
        {
            return FunctionsServal.calcParameter(functionType, functionParameters, new[] { materialCount });
        }

        public static int calcStatusValue(int initialValue, int currentLevel, NumericalFunctionType functionType, int[] functionParameters, int growthCurveCoefficientThreshold, int growthCurveCoefficient)
        {
            var currentLevelStatus = calcCurrentLevelRawStatusValue(initialValue, currentLevel, functionType, functionParameters);
            if (growthCurveCoefficientThreshold >= currentLevel)
                return currentLevelStatus;

            var thresholdLevelStatus = calcCurrentLevelRawStatusValue(initialValue, growthCurveCoefficientThreshold, functionType, functionParameters);
            var growthCappedValue = calcOverThresholdStatusDiffValue(currentLevelStatus, thresholdLevelStatus, growthCurveCoefficient);

            return thresholdLevelStatus + growthCappedValue;
        }

        public static int calcCurrentLevelRawStatusValue(int initialValue, int currentLevel, NumericalFunctionType functionType, int[] functionParameters)
        {
            return initialValue + FunctionsServal.calcParameter(functionType, functionParameters, new[] { currentLevel });
        }

        public static int calcOverThresholdStatusDiffValue(int currentLevelStatus, int thresholdLevelStatus, int growthCurveCoefficient)
        {
            return (currentLevelStatus - thresholdLevelStatus) * growthCurveCoefficient / 1000;
        }
    }
}
