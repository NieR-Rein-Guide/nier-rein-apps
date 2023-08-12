using NierReincarnation.Core.Dark.Generated.Type;
using NierReincarnation.Core.Dark.Status;

namespace NierReincarnation.Core.Dark.Calculator;

public static class CalculatorDataCostumeLevelBonus
{
    public static bool CreateCostumeLevelBonusStatusList(long userId, int characterId, List<DataCostumeLevelBonusStatus> costumeLevelBonusStatusList)
    {
        var table = DatabaseDefine.User.EntityIUserCharacterCostumeLevelBonusTable;
        var range = table.FindByCharacterId(characterId);

        foreach (var item in range)
        {
            var levelBonusStatus = CreateDataCostumeLevelBonusStatus(item);
            costumeLevelBonusStatusList.Add(levelBonusStatus);
        }

        return true;
    }

    private static DataCostumeLevelBonusStatus CreateDataCostumeLevelBonusStatus(EntityIUserCharacterCostumeLevelBonus entity)
    {
        return CreateDataCostumeLevelBonusStatus(entity.Agility, entity.Attack, entity.CriticalAttack, entity.CriticalRatio, 0, entity.Hp, entity.Vitality, entity.StatusCalculationType);
    }

    public static DataCostumeLevelBonusStatus CreateDataCostumeLevelBonusStatus(int agility, int attack, int criticalAttack, int criticalRatio, int evasionRatio, int hp, int vitality, StatusCalculationType statusCalculationType)
    {
        return new DataCostumeLevelBonusStatus
        {
            StatusCalculationType = statusCalculationType,
            StatusChangeValue = new StatusValue(agility, attack, criticalAttack, criticalRatio, evasionRatio, hp, vitality)
        };
    }
}
