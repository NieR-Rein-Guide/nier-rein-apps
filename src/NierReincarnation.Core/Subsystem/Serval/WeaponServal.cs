namespace NierReincarnation.Core.Subsystem.Serval;

public static class WeaponServal
{
    public static int CalcMaxLevel(int limitBreakCount, int awakenLevelLimitUp, NumericalFunctionType functionType, int[] functionParameters)
    {
        return awakenLevelLimitUp + FunctionsServal.calcParameter(functionType, functionParameters, new[] { limitBreakCount });
    }

    public static int CalcMaxSkillLevel(int limitBreakCount, NumericalFunctionType functionType, int[] functionParameters)
    {
        return FunctionsServal.calcParameter(functionType, functionParameters, new[] { limitBreakCount });
    }

    public static int CalcMaxAbilityLevel(int limitBreakCount, NumericalFunctionType functionType, int[] functionParameters)
    {
        return FunctionsServal.calcParameter(functionType, functionParameters, new[] { limitBreakCount });
    }

    public static int calcSellPrice(int weaponLevel, NumericalFunctionType functionType, int[] functionParameters)
    {
        return FunctionsServal.calcParameter(functionType, functionParameters, new[] { weaponLevel });
    }

    public static int calcRequiredGoldForEnhancementByWeapon(int weaponCount, NumericalFunctionType functionType, int[] functionParameters)
    {
        return FunctionsServal.calcParameter(functionType, functionParameters, new[] { weaponCount });
    }

    public static int calcRequiredGoldForEnhancementByMaterial(int materialCount, NumericalFunctionType functionType, int[] functionParameters)
    {
        return FunctionsServal.calcParameter(functionType, functionParameters, new[] { materialCount });
    }

    public static int calcEnhancementExpByMaterial(int baseValue, bool isSameWeaponType, int weaponCoefficientPermil)
    {
        return EnhancementServal.calcEnhancementExpByMaterial(baseValue, isSameWeaponType, weaponCoefficientPermil);
    }

    public static int calcEnhancementExpByWeapon(int baseValue, int exp, bool isSameWeaponType, int coefficientPermil, int weaponCoefficientPermil)
    {
        return EnhancementServal.calcEnhancementExpByWeapon(baseValue, exp, isSameWeaponType, coefficientPermil, weaponCoefficientPermil);
    }

    public static int calcRequiredGoldForLimitBreakByWeapon(int weaponCount, NumericalFunctionType functionType, int[] functionParameters)
    {
        return FunctionsServal.calcParameter(functionType, functionParameters, new[] { weaponCount });
    }

    public static int calcRequiredGoldForEvolution(int materialCount, NumericalFunctionType functionType, int[] functionParameters)
    {
        return FunctionsServal.calcParameter(functionType, functionParameters, new[] { materialCount });
    }

    public static int calcRequiredGoldForSkillEnhancement(int enhancedLevel, NumericalFunctionType functionType, int[] functionParameters)
    {
        return FunctionsServal.calcParameter(functionType, functionParameters, new[] { enhancedLevel });
    }

    public static int calcRequiredGoldForAbilityEnhancement(int enhancedLevel, NumericalFunctionType functionType, int[] functionParameters)
    {
        return FunctionsServal.calcParameter(functionType, functionParameters, new[] { enhancedLevel });
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
