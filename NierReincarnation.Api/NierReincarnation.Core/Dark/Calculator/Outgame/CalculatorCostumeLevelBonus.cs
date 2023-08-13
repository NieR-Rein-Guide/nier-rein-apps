using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark.Calculator.Outgame;

public static class CalculatorCostumeLevelBonus
{
    public static readonly int kStatusDataListCapacity = 2;
    private static readonly int kUnReleasedCostumeBonusLevel;
    private static readonly int kEmptyEffectValue;
    public static readonly StatusValue kDefaultCostumeBonusLevelStatus = new(kEmptyEffectValue, kEmptyEffectValue, kEmptyEffectValue, kEmptyEffectValue, 0, kEmptyEffectValue, kEmptyEffectValue);

    public static void CreateCostumeLevelBonusStatusList(long userId, int characterId, List<DataCostumeLevelBonusStatus> dataCostumeLevelBonusStatusList)
    {
        CalculatorDataCostumeLevelBonus.CreateCostumeLevelBonusStatusList(userId, characterId, dataCostumeLevelBonusStatusList);
    }
}
